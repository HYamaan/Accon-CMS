using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.News;
using AcconAPI.Domain.Entities.News;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.NewsSection.UpdateNews;

public class UpdateNewsCommandHandler:IRequestHandler<UpdateNewsCommandRequest,ResponseModel<UpdateNewsCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.NewsPage> _newsPageRepository;
    private readonly IGenericRepository<News> _newsRepository;
    private readonly IGenericRepository<Domain.Entities.File.News.NewsBanner> _newsBannerRepository;
    private readonly IGenericRepository<Domain.Entities.File.News.NewsPhoto> _newsPhotoRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    private readonly ICreateNewsCommandRequestValidator _createNewsCommandRequestValidator;
    private readonly IUpdateNewsCommandRequestValidator _updateNewsCommandRequestValidator;


    public UpdateNewsCommandHandler(IGenericRepository<NewsPage> newsPageRepository, IGenericRepository<News> newsRepository, IGenericRepository<NewsBanner> newsBannerRepository, IGenericRepository<NewsPhoto> newsPhotoRepository, IStorageService storageService, IFileCheckHelper fileCheckHelper, ICreateNewsCommandRequestValidator createNewsCommandRequestValidator, IUpdateNewsCommandRequestValidator updateNewsCommandRequestValidator)
    {
        _newsPageRepository = newsPageRepository;
        _newsRepository = newsRepository;
        _newsBannerRepository = newsBannerRepository;
        _newsPhotoRepository = newsPhotoRepository;
        _storageService = storageService;
        _fileCheckHelper = fileCheckHelper;
        _createNewsCommandRequestValidator = createNewsCommandRequestValidator;
        _updateNewsCommandRequestValidator = updateNewsCommandRequestValidator;
    }

    public async Task<ResponseModel<UpdateNewsCommandResponse>> Handle(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
    {
       if(request.Id == null)
           return await CreateNews(request, cancellationToken);
       return await UpdateNews(request, cancellationToken);
    }
    private async Task<ResponseModel<UpdateNewsCommandResponse>> CreateNews(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = await _createNewsCommandRequestValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return ResponseModel<UpdateNewsCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                    .ToList());

            if (!await _fileCheckHelper.CheckImageFormat(request.BannerPhoto))
                return ResponseModel<UpdateNewsCommandResponse>.Fail("Banner is not valid");
            if (!await _fileCheckHelper.CheckImageFormat(request.FeaturedPhoto))
                return ResponseModel<UpdateNewsCommandResponse>.Fail("Photo is not valid");

            await _newsRepository.BeginTransactionAsync();
            var bannerPhoto = await _storageService.UploadAsync("files", request.BannerPhoto);
            var featuredPhoto = await _storageService.UploadAsync("files", request.FeaturedPhoto);
            var bannerPhotoModel = new NewsBanner()
            {
                Path = bannerPhoto.pathOrContainerName,
                FileName = bannerPhoto.fileName,
                Storage = _storageService.StorageName
            };
            var featuredPhotoModel = new NewsPhoto()
            {
                Path = featuredPhoto.pathOrContainerName,
                FileName = featuredPhoto.fileName,
                Storage = _storageService.StorageName
            };
            await _newsBannerRepository.AddAsync(bannerPhotoModel);
            await _newsPhotoRepository.AddAsync(featuredPhotoModel);

            var newsPage = await _newsPageRepository.GetAll().FirstOrDefaultAsync();
            var createNews = new News()
            {
                Title = request.Title,
                Content = request.Content,
                ShortContent = request.ShortContent,
                IsPublished = request.IsPublished,
                PublishDate = DateTime.SpecifyKind(request.PublishDate, DateTimeKind.Utc),
                NewsCategoryId = request.NewsCategoryId,
                CommentShow = request.CommentShow,
                MetaTitle = request.MetaTitle,
                MetaDescription = request.MetaDescription,
                MetaKeywords = request.MetaKeyword,
                Photo = featuredPhotoModel,
                Banner = bannerPhotoModel,
                NewsPageId = newsPage.Id
            };
            await _newsRepository.AddAsync(createNews);

            await _newsBannerRepository.SaveAsync();
            await _newsPhotoRepository.SaveAsync();
            await _newsRepository.CommitTransactionAsync();
            await _newsRepository.SaveAsync();
            return ResponseModel<UpdateNewsCommandResponse>.Success();
        }
        catch (Exception e)
        {
            return ResponseModel<UpdateNewsCommandResponse>.Fail(e.Message);
        }

    }

    private async Task<ResponseModel<UpdateNewsCommandResponse>> UpdateNews(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _updateNewsCommandRequestValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ResponseModel<UpdateNewsCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage)
                           .ToList());

        try
        {
            var findNews = await _newsRepository.GetWhere(x => x.Id == request.Id)
                .Include(x => x.Photo)
                .Include(x => x.Banner)
                .FirstOrDefaultAsync();

            if (findNews == null)
                return ResponseModel<UpdateNewsCommandResponse>.Fail("News not found");
            if(findNews.Title != request.Title)
                findNews.Title = request.Title;
            if(findNews.Content != request.Content)
                findNews.Content = request.Content;
            if(findNews.ShortContent != request.ShortContent)
                findNews.ShortContent = request.ShortContent;
            if(findNews.IsPublished != request.IsPublished)
                findNews.IsPublished = request.IsPublished;
            if (findNews.PublishDate != request.PublishDate)
                findNews.PublishDate = DateTime.SpecifyKind(request.PublishDate, DateTimeKind.Utc);
            if (findNews.NewsCategoryId != request.NewsCategoryId)
                findNews.NewsCategoryId = request.NewsCategoryId;
            if(findNews.CommentShow != request.CommentShow)
                findNews.CommentShow = request.CommentShow;
            if(findNews.MetaTitle != request.MetaTitle)
                findNews.MetaTitle = request.MetaTitle;
            if(findNews.MetaDescription != request.MetaDescription)
                findNews.MetaDescription = request.MetaDescription;
            if(findNews.MetaKeywords != request.MetaKeyword)
                findNews.MetaKeywords = request.MetaKeyword;
            if (request.FeaturedPhoto != null && request.FeaturedPhoto?.FileName != findNews.Photo.FileName)
            {
                if (!await _fileCheckHelper.CheckImageFormat(request.FeaturedPhoto))
                    return ResponseModel<UpdateNewsCommandResponse>.Fail("Photo is not valid");

                var esult = await _storageService.UploadAsync("files", request.FeaturedPhoto);
                var photo = new NewsPhoto()
                {
                    Path = esult.pathOrContainerName,
                    FileName = esult.fileName,
                    Storage = _storageService.StorageName
                };
                await _newsPhotoRepository.AddAsync(photo);
                findNews.Photo = photo;
                await _newsPhotoRepository.SaveAsync();
            }

            if (request.BannerPhoto != null && request.BannerPhoto.FileName != findNews.Banner.FileName)
            {
                if (!await _fileCheckHelper.CheckImageFormat(request.BannerPhoto))
                    return ResponseModel<UpdateNewsCommandResponse>.Fail("Banner is not valid");

                var esult = await _storageService.UploadAsync("files", request.BannerPhoto);
                var photo = new NewsBanner()
                {
                    Path = esult.pathOrContainerName,
                    FileName = esult.fileName,
                    Storage = _storageService.StorageName
                };
                await _newsBannerRepository.AddAsync(photo);
                findNews.Banner = photo;
                await _newsBannerRepository.SaveAsync();
            }
            _newsRepository.Update(findNews);
            await _newsRepository.SaveAsync();
            return ResponseModel<UpdateNewsCommandResponse>.Success();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}