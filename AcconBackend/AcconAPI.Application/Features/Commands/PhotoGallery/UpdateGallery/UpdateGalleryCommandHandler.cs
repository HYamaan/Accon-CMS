using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.Gallery;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.PhotoGallery.UpdateGallery;

public class UpdateGalleryCommandHandler : IRequestHandler<UpdateGalleryCommandRequest, ResponseModel<UpdateGalleryCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Gallery.Gallery> _galleryRepository;
    private readonly IGenericRepository<Domain.Entities.File.GalleryPhoto> _galleryImageRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public UpdateGalleryCommandHandler(IGenericRepository<Gallery> galleryRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService, IGenericRepository<GalleryPhoto> galleryImageRepository)
    {
        _galleryRepository = galleryRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
        _galleryImageRepository = galleryImageRepository;
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
            if (request.Photo == null && !await _fileCheckHelper.CheckImageFormat(request.Photo))
            {
                return ResponseModel<UpdateGalleryCommandResponse>.Fail("Photo is required");
            }

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