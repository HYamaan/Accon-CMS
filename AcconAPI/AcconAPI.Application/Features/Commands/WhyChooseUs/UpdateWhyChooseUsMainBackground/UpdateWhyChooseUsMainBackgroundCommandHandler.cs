using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.WhyChooseUs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUsMainBackground;

public class UpdateWhyChooseUsMainBackgroundCommandHandler : IRequestHandler<UpdateWhyChooseUsMainBackgroundRequest, ResponseModel<UpdateWhyChooseUsMainBackgroundResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.WhyChooseUs.ChooseUseBackgroundPhoto> _chooseUsBackgroundPhotoRepository;
    private readonly IFileCheckHelper _fileCheckHelper;
    private readonly IStorageService _storageService;

    public UpdateWhyChooseUsMainBackgroundCommandHandler(IGenericRepository<ChooseUseBackgroundPhoto> chooseUsBackgroundPhotoRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService)
    {
        _chooseUsBackgroundPhotoRepository = chooseUsBackgroundPhotoRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
    }

    public async Task<ResponseModel<UpdateWhyChooseUsMainBackgroundResponse>> Handle(UpdateWhyChooseUsMainBackgroundRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
                return ResponseModel<UpdateWhyChooseUsMainBackgroundResponse>.Fail("File extension is not valid.");

            var getBackgroundPhoto = await _chooseUsBackgroundPhotoRepository.GetAll().FirstOrDefaultAsync();
            await _chooseUsBackgroundPhotoRepository.BeginTransactionAsync();
            if (getBackgroundPhoto != null)
            {
                await _storageService.DeleteAsync(getBackgroundPhoto.Path, getBackgroundPhoto.FileName);
                await _chooseUsBackgroundPhotoRepository.RemoveAsync(getBackgroundPhoto.Id.ToString());
            }

            var storage = await _storageService.UploadAsync("files", request.Photo);
            var chooseUsBackgroundPhoto = new ChooseUseBackgroundPhoto()
            {
                Path = storage.pathOrContainerName,
                FileName = storage.fileName,
                Storage = _storageService.StorageName
            };
            await _chooseUsBackgroundPhotoRepository.AddAsync(chooseUsBackgroundPhoto);

            await _chooseUsBackgroundPhotoRepository.CommitTransactionAsync();
            await _chooseUsBackgroundPhotoRepository.SaveAsync();
            return ResponseModel<UpdateWhyChooseUsMainBackgroundResponse>.Success(new UpdateWhyChooseUsMainBackgroundResponse()
            {
                Photo = chooseUsBackgroundPhoto.Path
            });
        }
        catch (Exception e)
        {
            return ResponseModel<UpdateWhyChooseUsMainBackgroundResponse>.Fail(e.Message);
        }
    }
}