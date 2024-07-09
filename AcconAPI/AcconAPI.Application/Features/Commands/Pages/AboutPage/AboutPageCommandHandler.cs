using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Pages.AboutPage
{
    public class AboutPageCommandHandler : IRequestHandler<AboutPageCommandRequest, ResponseModel<AboutPageCommandResponse>>
    {
        private readonly IGenericRepository<Domain.Entities.Page.AboutPage> _aboutPageRepository;
        private readonly IGenericRepository<Domain.Entities.File.AboutPagePhoto> _aboutPagePhotoRepository;
        private readonly IStorageService _storageService;
        private readonly IFileCheckHelper _fileCheckHelper;
        private readonly IValidator<AboutPageCommandRequest> _validator;

        public AboutPageCommandHandler(
            IGenericRepository<Domain.Entities.Page.AboutPage> aboutPageRepository,
            IValidator<AboutPageCommandRequest> validator,
            IFileCheckHelper fileCheckHelper,
            IGenericRepository<AboutPagePhoto> aboutPagePhotoRepository,
            IStorageService storageService)
        {
            _aboutPageRepository = aboutPageRepository;
            _aboutPagePhotoRepository = aboutPagePhotoRepository;
            _storageService = storageService;
            _validator = validator;
            _fileCheckHelper = fileCheckHelper;
        }

        public async Task<ResponseModel<AboutPageCommandResponse>> Handle(AboutPageCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<AboutPageCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

    

            await _aboutPageRepository.BeginTransactionAsync();

            try
            {
                var aboutPhotoModel = new AboutPagePhoto();

                var findAboutPage = await _aboutPageRepository.GetAll()
                    .Include(x => x.Photo)
                    .FirstOrDefaultAsync();

                if (findAboutPage != null && (findAboutPage.Photo == null && request.Photo == null))
                {
                   return ResponseModel<AboutPageCommandResponse>.Fail("Photo is required");
                }

                if (request.Photo != null)
                {
                    var photoData = await _storageService.UploadAsync("files", request.Photo);
                    aboutPhotoModel = new AboutPagePhoto()
                    {
                        FileName = photoData.fileName,
                        Path = photoData.pathOrContainerName,
                        Storage = _storageService.StorageName,
                    };
                    if (request.Photo != null && !await _fileCheckHelper.CheckImageFormat(request.Photo))
                    {
                        return ResponseModel<AboutPageCommandResponse>.Fail("Invalid Image Format");
                    }
                    await _aboutPagePhotoRepository.AddAsync(aboutPhotoModel);
                }

                if (findAboutPage != null)
                {
                    
                    findAboutPage.Content = request.AboutContent;
                    findAboutPage.Heading = request.AboutHeader;
                    findAboutPage.MissionContent = request.MissionContent;
                    findAboutPage.MissionHeading = request.MissionHeader;
                    findAboutPage.VisionContent = request.VisionContent;
                    findAboutPage.VisionHeading = request.VisionHeader;
                    findAboutPage.MetaDescription = request.MetaDescription;
                    findAboutPage.MetaKeywords = request.MetaKeywords;
                    findAboutPage.MetaTitle = request.MetaTitle;
                    if (request.Photo != null)
                    {
                        findAboutPage.Photo = aboutPhotoModel;
                    }
                    _aboutPageRepository.Update(findAboutPage);
                }
                else
                {
                    var aboutPageModel = new Domain.Entities.Page.AboutPage()
                    {
                        Content = request.AboutContent,
                        Heading = request.AboutHeader,
                        MissionContent = request.MissionContent,
                        MissionHeading = request.MissionHeader,
                        VisionContent = request.VisionContent,
                        VisionHeading = request.VisionHeader,
                        MetaDescription = request.MetaDescription,
                        MetaKeywords = request.MetaKeywords,
                        MetaTitle = request.MetaTitle,
                        Photo = aboutPhotoModel
                    };

                    await _aboutPageRepository.AddAsync(aboutPageModel);
                }
                await _aboutPagePhotoRepository.SaveAsync();
                await _aboutPageRepository.SaveAsync();
                await _aboutPageRepository.CommitTransactionAsync();

                return ResponseModel<AboutPageCommandResponse>.Success("About Page Created/Updated Successfully");
            }
            catch (Exception e)
            {
                await _aboutPageRepository.RollbackTransactionAsync();
              return ResponseModel<AboutPageCommandResponse>.Fail(e.Message);
            }
        }

    }

}
