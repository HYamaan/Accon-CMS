using AcconAPI.Application.Features.Commands.Slider;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.File.Service;
using AcconAPI.Domain.Entities.Page;
using AcconAPI.Domain.Entities.Service;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace AcconAPI.Application.Features.Commands.Service.UpdateService;

public class
    UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommandRequest,
        ResponseModel<UpdateServiceCommandResponse>>
{
    private readonly IGenericRepository<ServiceSection> _serviceRepository;
    private readonly IGenericRepository<ServicePage> _servicePageRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _imageFileCheckHelper;
    private readonly IUpdateServiceCommandRequestValidator _validator;
    private readonly IUpdateServiceContentCommandRequestValidator _contentValidator;


    public UpdateServiceCommandHandler(IGenericRepository<ServiceSection> serviceRepository, IFileCheckHelper imageFileCheckHelper, IStorageService storageService, IGenericRepository<ServicePage> servicePageRepository, IUpdateServiceCommandRequestValidator validator, IUpdateServiceContentCommandRequestValidator contentValidator)
    {
        _serviceRepository = serviceRepository;
        _imageFileCheckHelper = imageFileCheckHelper;
        _storageService = storageService;
        _servicePageRepository = servicePageRepository;
        _validator = validator;
        _contentValidator = contentValidator;
    }

    public async Task<ResponseModel<UpdateServiceCommandResponse>> Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
    {


        if (request.Id == null)
        {
            return await AddService(request, cancellationToken);
        }
        else
        {
            return await UpdateService(request, cancellationToken);

        }

    }

    private async Task<ResponseModel<UpdateServiceCommandResponse>> AddService(
        UpdateServiceCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<UpdateServiceCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

        if (!await _imageFileCheckHelper.CheckImageFormat(request.Photo) &&

            !await _imageFileCheckHelper.CheckImageFormat(request.Banner))
        {
            return ResponseModel<UpdateServiceCommandResponse>.Fail("Invalid Image Format");
        }


        await _serviceRepository.BeginTransactionAsync();
        try
        {

            var servicePage = await _servicePageRepository.GetAll().FirstOrDefaultAsync();

            var photoData = await _storageService.UploadAsync("files", request.Photo);
            var servicePhotoModel = new ServicePhoto
            {
                FileName = photoData.fileName,
                Path = photoData.pathOrContainerName,
                Storage = _storageService.StorageName

            };
            var bannerData = await _storageService.UploadAsync("files", request.Banner);
            var serviceBannerModel = new ServiceBanner
            {
                FileName = bannerData.fileName,
                Path = bannerData.pathOrContainerName,
                Storage = _storageService.StorageName
            };

            var serviceSection = new ServiceSection()
            {
                Title = request.Heading,
                ShortContent = request.ShortContent,
                Content = request.Content,
                Photo = servicePhotoModel,
                Banner = serviceBannerModel,
                IsPublished = request.IsPublished,
                MetaTitle = request.MetaTitle,
                MetaDescription = request.MetaDescription,
                MetaKeywords = request.MetaKeywords,
                ServicePage = servicePage
            };

            await _serviceRepository.AddAsync(serviceSection);

            await _serviceRepository.SaveAsync();
            await _serviceRepository.CommitTransactionAsync();
            return ResponseModel<UpdateServiceCommandResponse>.Success();
        }
        catch (Exception e)
        {
            await _serviceRepository.RollbackTransactionAsync();
            return ResponseModel<UpdateServiceCommandResponse>.Fail(e.Message);
        }
    }


    private async Task<ResponseModel<UpdateServiceCommandResponse>> UpdateService(UpdateServiceCommandRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _contentValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<UpdateServiceCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

        await _serviceRepository.BeginTransactionAsync();
        try
        {
            var serviceInfo = await _serviceRepository.GetWhere(p => p.Id == request.Id)
                .Include(p => p.Photo).Include(p => p.Banner).FirstOrDefaultAsync();
            if (serviceInfo == null)
            {
                return await AddService(request, cancellationToken);
            }
            if (serviceInfo.Title != request.Heading) serviceInfo.Title = request.Heading;
            if (serviceInfo.ShortContent != request.ShortContent) serviceInfo.ShortContent = request.ShortContent;
            if (serviceInfo.Content != request.Content) serviceInfo.Content = request.Content;
            if (serviceInfo.IsPublished != request.IsPublished) serviceInfo.IsPublished = request.IsPublished;
            if (serviceInfo.MetaTitle != request.MetaTitle) serviceInfo.MetaTitle = request.MetaTitle;
            if (serviceInfo.MetaDescription != request.MetaDescription) serviceInfo.MetaDescription = request.MetaDescription;
            if (serviceInfo.MetaKeywords != request.MetaKeywords) serviceInfo.MetaKeywords = request.MetaKeywords;

            if (request.Photo != null && serviceInfo.Photo.FileName != request.Photo.FileName && request.Photo.Length > 0)
            {
                var photoData = await _storageService.UploadAsync("files", request.Photo);
                serviceInfo.Photo.FileName = photoData.fileName;
                serviceInfo.Photo.Path = photoData.pathOrContainerName;
                serviceInfo.Photo.Storage = _storageService.StorageName;
            }

            if (request.Banner != null && serviceInfo.Banner.FileName != request.Banner.FileName && request.Banner.Length > 0)
            {
                var bannerData = await _storageService.UploadAsync("files", request.Banner);
                serviceInfo.Banner.FileName = bannerData.fileName;
                serviceInfo.Banner.Path = bannerData.pathOrContainerName;
                serviceInfo.Banner.Storage = _storageService.StorageName;
            }

            _serviceRepository.Update(serviceInfo);
            await _serviceRepository.CommitTransactionAsync();
            await _serviceRepository.SaveAsync();
            return ResponseModel<UpdateServiceCommandResponse>.Success();
        }
        catch (Exception e)
        {
            await _serviceRepository.RollbackTransactionAsync();
            return ResponseModel<UpdateServiceCommandResponse>.Fail(e.Message);
        }
    }

}