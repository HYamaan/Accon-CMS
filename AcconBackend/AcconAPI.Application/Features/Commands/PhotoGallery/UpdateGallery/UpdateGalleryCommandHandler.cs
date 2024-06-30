using AcconAPI.Application.Features.Commands.Service;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.Page;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Gallery = AcconAPI.Domain.Entities.Gallery.Gallery;

namespace AcconAPI.Application.Features.Commands.PhotoGallery.UpdateGallery;

public class UpdateGalleryCommandHandler : IRequestHandler<UpdateGalleryCommandRequest, ResponseModel<UpdateGalleryCommandResponse>>
{
    private readonly IGenericRepository<GalleryPage> _galleryPageRepository;
    private readonly IGenericRepository<Domain.Entities.Gallery.Gallery> _galleryRepository;
    private readonly IGenericRepository<Domain.Entities.File.GalleryPhoto> _galleryImageRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    private readonly IUpdatePhotoGalleryValidator _updatePhotoGalleryValidator;
    private readonly ICreatePhotoGalleryValidator _createPhotoGalleryValidator;


    public UpdateGalleryCommandHandler(IGenericRepository<Gallery> galleryRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService, IGenericRepository<GalleryPhoto> galleryImageRepository, IUpdatePhotoGalleryValidator updatePhotoGalleryValidator, ICreatePhotoGalleryValidator createPhotoGalleryValidator, IGenericRepository<GalleryPage> galleryPageRepository)
    {
        _galleryRepository = galleryRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
        _galleryImageRepository = galleryImageRepository;
        _updatePhotoGalleryValidator = updatePhotoGalleryValidator;
        _createPhotoGalleryValidator = createPhotoGalleryValidator;
        _galleryPageRepository = galleryPageRepository;
    }

    public async Task<ResponseModel<UpdateGalleryCommandResponse>> Handle(UpdateGalleryCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
        {
            return await CreateGalleryImage(request, cancellationToken);
        }

        return await UpdateGalleryImage(request, cancellationToken);

    }

    public async Task<ResponseModel<UpdateGalleryCommandResponse>> CreateGalleryImage(
        UpdateGalleryCommandRequest request, CancellationToken cancellationToken)
    {
 
        try
        {
            var validationResult = await _createPhotoGalleryValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<UpdateGalleryCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            {
                return ResponseModel<UpdateGalleryCommandResponse>.Fail("Photo is not img");
            }
            var galleryPage = await _galleryPageRepository.GetAll().FirstOrDefaultAsync();

            await _galleryImageRepository.BeginTransactionAsync();

            var updateGallerImage = await _storageService.UploadAsync("files", request.Photo);
            var galleryImage = new GalleryPhoto()
            {
                Path = updateGallerImage.pathOrContainerName,
                FileName = updateGallerImage.fileName,
                Storage = _storageService.StorageName
            };
            var gallery = new Gallery()
            {
                Title = request.Title,
                GalleryPhoto = galleryImage,
                IsVisible = request.VisiblePlace,
                GalleryPage = galleryPage
            };
            await _galleryRepository.AddAsync(gallery);
            await _galleryImageRepository.AddAsync(galleryImage);
            await _galleryImageRepository.CommitTransactionAsync();
            await _galleryImageRepository.SaveAsync();
            await _galleryRepository.SaveAsync();
            return ResponseModel<UpdateGalleryCommandResponse>.Success();
        }
        catch (Exception e)
        {
            await _galleryImageRepository.RollbackTransactionAsync();
            return ResponseModel<UpdateGalleryCommandResponse>.Fail(e.Message);

        }
    }

    public async Task<ResponseModel<UpdateGalleryCommandResponse>> UpdateGalleryImage(
        UpdateGalleryCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = await _updatePhotoGalleryValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<UpdateGalleryCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            var gallery = await _galleryRepository.GetWhere(ux => ux.Id == request.Id)
                .Include(ux => ux.GalleryPhoto)
                .FirstOrDefaultAsync(cancellationToken);
            if (gallery == null)
            {
                return ResponseModel<UpdateGalleryCommandResponse>.Fail("Gallery not found");
            }

            return ResponseModel<UpdateGalleryCommandResponse>.Success();
        }
        catch (Exception e)
        {
            return ResponseModel<UpdateGalleryCommandResponse>.Fail(e.Message);
        }


    }
}