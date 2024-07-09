using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.Logo.AdminLogo;

public class AdminLogoCommandHandler:IRequestHandler<AdminLogoCommandRequest,ResponseModel<AdminLogoCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.AdminLogo> _adminLogoRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public AdminLogoCommandHandler(IGenericRepository<Domain.Entities.File.Settings.AdminLogo> adminLogoRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService)
    {
        _adminLogoRepository = adminLogoRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
    }

    public async Task<ResponseModel<AdminLogoCommandResponse>> Handle(AdminLogoCommandRequest request, CancellationToken cancellationToken)
    {
        if(request.Photo == null)
            return ResponseModel<AdminLogoCommandResponse>.Fail("Photo is required");

        if(!await _fileCheckHelper.CheckImageFormat(request.Photo))
            return ResponseModel<AdminLogoCommandResponse>.Fail("Photo is not an image");

        var setStorage = await _storageService.UploadAsync("files", request.Photo);
        
        var logo = new Domain.Entities.File.Settings.AdminLogo
        {
            Path = setStorage.pathOrContainerName,
            FileName = setStorage.fileName,
            Storage = _storageService.StorageName
        };
        var result = await _adminLogoRepository.AddAsync(logo);
        if(result == null)
            return ResponseModel<AdminLogoCommandResponse>.Fail("Failed to save logo");
        await _adminLogoRepository.SaveAsync();

        return ResponseModel<AdminLogoCommandResponse>.Success(new AdminLogoCommandResponse
        {
            Photo = logo.Path
        });
    }
}