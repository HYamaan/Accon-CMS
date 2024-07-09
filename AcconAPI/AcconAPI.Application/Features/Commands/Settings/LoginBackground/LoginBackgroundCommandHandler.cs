using AcconAPI.Application.Features.Commands.Settings.Favicon;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.LoginBackground;

public class LoginBackgroundCommandHandler:IRequestHandler<LoginBackgroundCommandRequest,ResponseModel<LoginBackgroundCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.LoginBackground> _loginBackgroundRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public LoginBackgroundCommandHandler(IGenericRepository<Domain.Entities.File.Settings.LoginBackground> loginBackgroundRepository, IFileCheckHelper fileCheckHelper, IStorageService storageService)
    {
        _loginBackgroundRepository = loginBackgroundRepository;
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
    }

    public async Task<ResponseModel<LoginBackgroundCommandResponse>> Handle(LoginBackgroundCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Photo == null)
            return ResponseModel<LoginBackgroundCommandResponse>.Fail("Photo is required");

        if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            return ResponseModel<LoginBackgroundCommandResponse>.Fail("Photo is not an image");

        var setStorage = await _storageService.UploadAsync("files", request.Photo);

        var logo = new Domain.Entities.File.Settings.LoginBackground()
        {
            Path = setStorage.pathOrContainerName,
            FileName = setStorage.fileName,
            Storage = _storageService.StorageName
        };
        var result = await _loginBackgroundRepository.AddAsync(logo);
        if (result == null)
            return ResponseModel<LoginBackgroundCommandResponse>.Fail("Failed to save logo");
        await _loginBackgroundRepository.SaveAsync();

        return ResponseModel<LoginBackgroundCommandResponse>.Success(new LoginBackgroundCommandResponse
        {
            Photo = logo.Path
        });
    }
}