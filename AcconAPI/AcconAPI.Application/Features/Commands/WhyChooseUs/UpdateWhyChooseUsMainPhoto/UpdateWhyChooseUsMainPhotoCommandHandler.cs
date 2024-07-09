using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.WhyChooseUs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUsMainPhoto;

public class UpdateWhyChooseUsMainPhotoCommandHandler : IRequestHandler<UpdateWhyChooseUsMainPhotoCommandRequest, ResponseModel<UpdateWhyChooseUsMainPhotoCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.WhyChooseUs.ChooseUsMainPhoto> _chooseUsMainPhotoRepository;
    private readonly IFileCheckHelper _fileCheckHelper;
    private readonly IStorageService _storageService;

    public UpdateWhyChooseUsMainPhotoCommandHandler(IGenericRepository<ChooseUsMainPhoto> chooseUsMainPhotoRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService)
    {
        _chooseUsMainPhotoRepository = chooseUsMainPhotoRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
    }

    public async Task<ResponseModel<UpdateWhyChooseUsMainPhotoCommandResponse>> Handle(UpdateWhyChooseUsMainPhotoCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
                return ResponseModel<UpdateWhyChooseUsMainPhotoCommandResponse>.Fail("File extension is not valid.");


            var getMainPhoto = await _chooseUsMainPhotoRepository.GetAll().FirstOrDefaultAsync();
            await _chooseUsMainPhotoRepository.BeginTransactionAsync();
            if (getMainPhoto != null)
            {
                await _storageService.DeleteAsync(getMainPhoto.Path, getMainPhoto.FileName);
                await _chooseUsMainPhotoRepository.RemoveAsync(getMainPhoto.Id.ToString());
            }

            var storage = await _storageService.UploadAsync("files", request.Photo);
            var chooseUsMainPhoto = new ChooseUsMainPhoto()
            {
                Path = storage.pathOrContainerName,
                FileName = storage.fileName,
                Storage = _storageService.StorageName
            };
            await _chooseUsMainPhotoRepository.AddAsync(chooseUsMainPhoto);

            await _chooseUsMainPhotoRepository.CommitTransactionAsync();
            await _chooseUsMainPhotoRepository.SaveAsync();
            return ResponseModel<UpdateWhyChooseUsMainPhotoCommandResponse>.Success(new UpdateWhyChooseUsMainPhotoCommandResponse()
            {
                Photo = chooseUsMainPhoto.Path
            });

        }
        catch (Exception e)
        {
            await _chooseUsMainPhotoRepository.RollbackTransactionAsync();
            return ResponseModel<UpdateWhyChooseUsMainPhotoCommandResponse>.Fail(e.Message);
        }
    }
}