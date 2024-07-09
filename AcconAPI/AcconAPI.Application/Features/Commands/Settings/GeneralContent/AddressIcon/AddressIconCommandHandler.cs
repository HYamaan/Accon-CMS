using AcconAPI.Application.Features.Commands.Settings.Favicon;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.AddressIcon;

public class AddressIconCommandHandler:IRequestHandler<AddressIconCommandRequest, ResponseModel<AddressIconCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.FooterAdressIcon> _addressIconRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;


    public AddressIconCommandHandler(IGenericRepository<FooterAdressIcon> addressIconRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService)
    {
        _addressIconRepository = addressIconRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
    }

    public async Task<ResponseModel<AddressIconCommandResponse>> Handle(AddressIconCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Photo == null)
            return ResponseModel<AddressIconCommandResponse>.Fail("Photo is required");

        if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            return ResponseModel<AddressIconCommandResponse>.Fail("Photo is not an image");

        var setStorage = await _storageService.UploadAsync("files", request.Photo);

        var logo = new Domain.Entities.File.Settings.FooterAdressIcon()
        {
            Path = setStorage.pathOrContainerName,
            FileName = setStorage.fileName,
            Storage = _storageService.StorageName
        };
        var result = await _addressIconRepository.AddAsync(logo);
        if (result == null)
            return ResponseModel<AddressIconCommandResponse>.Fail("Failed to save logo");
        await _addressIconRepository.SaveAsync();

        return ResponseModel<AddressIconCommandResponse>.Success(new AddressIconCommandResponse
        {
            Photo = logo.Path
        });
    }
}