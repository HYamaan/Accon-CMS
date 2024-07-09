using AcconAPI.Application.Features.Commands.Settings.GeneralContent.AddressIcon;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.PhoneIcon;

public class PhoneIconCommandHandler:IRequestHandler<PhoneIconCommandRequest, ResponseModel<PhoneIconCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.FooterPhoneIcon> _phoneIconRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public PhoneIconCommandHandler(IGenericRepository<FooterPhoneIcon> phoneIconepository, IStorageService storageService, IFileCheckHelper fileCheckHelper)
    {
        _phoneIconRepository = phoneIconepository;
        _storageService = storageService;
        _fileCheckHelper = fileCheckHelper;
    }

    public async Task<ResponseModel<PhoneIconCommandResponse>> Handle(PhoneIconCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Photo == null)
            return ResponseModel<PhoneIconCommandResponse>.Fail("Photo is required");

        if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            return ResponseModel<PhoneIconCommandResponse>.Fail("Photo is not an image");

        var setStorage = await _storageService.UploadAsync("files", request.Photo);

        var logo = new Domain.Entities.File.Settings.FooterPhoneIcon()
        {
            Path = setStorage.pathOrContainerName,
            FileName = setStorage.fileName,
            Storage = _storageService.StorageName
        };
        var result = await _phoneIconRepository.AddAsync(logo);
        if (result == null)
            return ResponseModel<PhoneIconCommandResponse>.Fail("Failed to save logo");
        await _phoneIconRepository.SaveAsync();

        return ResponseModel<PhoneIconCommandResponse>.Success(new PhoneIconCommandResponse
        {
            Photo = logo.Path
        });
    }
}