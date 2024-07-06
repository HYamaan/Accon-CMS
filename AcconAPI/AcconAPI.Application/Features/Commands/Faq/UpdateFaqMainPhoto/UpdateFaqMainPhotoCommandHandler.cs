using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Faq.UpdateFaqMainPhoto;

public class UpdateFaqMainPhotoCommandHandler:IRequestHandler<UpdateFaqMainPhotoCommandRequest,ResponseModel<UpdateFaqMainPhotoCommandResponse>>
{
    private readonly IGenericRepository<FaqMainPhoto> _faqMainPhotoRepository;
    private readonly IFileCheckHelper _fileCheckHelper;
    private readonly IStorageService _storageService;

    public UpdateFaqMainPhotoCommandHandler(IGenericRepository<FaqMainPhoto> faqMainPhotoRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService)
    {
        _faqMainPhotoRepository = faqMainPhotoRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
    }

    public async Task<ResponseModel<UpdateFaqMainPhotoCommandResponse>> Handle(UpdateFaqMainPhotoCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var getMainPhoto = await _faqMainPhotoRepository.GetAll().FirstOrDefaultAsync();
            if (getMainPhoto != null)
            {
                await _faqMainPhotoRepository.BeginTransactionAsync();
                await _storageService.DeleteAsync(getMainPhoto.Path, getMainPhoto.FileName);
                await _faqMainPhotoRepository.RemoveAsync(getMainPhoto.Id.ToString());
                await _faqMainPhotoRepository.SaveAsync();
                await _faqMainPhotoRepository.CommitTransactionAsync();
            }


            await _faqMainPhotoRepository.BeginTransactionAsync();
            var faqMainPhoto = await _storageService.UploadAsync("files", request.Photo);
            var faqMainPhotoEntity = new FaqMainPhoto()
            {
                Path = faqMainPhoto.pathOrContainerName,
                FileName = faqMainPhoto.fileName,
                Storage = _storageService.StorageName,
            };

            await _faqMainPhotoRepository.AddAsync(faqMainPhotoEntity);
            await _faqMainPhotoRepository.SaveAsync();
            await _faqMainPhotoRepository.CommitTransactionAsync();
            return ResponseModel<UpdateFaqMainPhotoCommandResponse>.Success(
                new UpdateFaqMainPhotoCommandResponse()
                {
                    Photo = faqMainPhotoEntity.Path
                }
                );
        }
        catch (Exception e)
        {
            await _faqMainPhotoRepository.RollbackTransactionAsync();
            return ResponseModel<UpdateFaqMainPhotoCommandResponse>.Fail(e.Message);
        }

    }

}