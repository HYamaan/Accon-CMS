using AcconAPI.Application.Features.Commands.Settings.Logo.AdminLogo;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.Favicon;

public class FaviconCommandHandler:IRequestHandler<FaviconCommandRequest,ResponseModel<FaviconCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.Favicon> _faviconRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public FaviconCommandHandler(IGenericRepository<Domain.Entities.File.Settings.Favicon> faviconRepository, IStorageService storageService, IFileCheckHelper fileCheckHelper)
    {
        _faviconRepository = faviconRepository;
        _storageService = storageService;
        _fileCheckHelper = fileCheckHelper;
    }

    public async Task<ResponseModel<FaviconCommandResponse>> Handle(FaviconCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Photo == null)
            return ResponseModel<FaviconCommandResponse>.Fail("Photo is required");

        if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            return ResponseModel<FaviconCommandResponse>.Fail("Photo is not an image");

        var setStorage = await _storageService.UploadAsync("files", request.Photo);

        var logo = new Domain.Entities.File.Settings.Favicon()
        {
            Path = setStorage.pathOrContainerName,
            FileName = setStorage.fileName,
            Storage = _storageService.StorageName
        };
        var result = await _faviconRepository.AddAsync(logo);
        if (result == null)
            return ResponseModel<FaviconCommandResponse>.Fail("Failed to save logo");
        await _faviconRepository.SaveAsync();

        return ResponseModel<FaviconCommandResponse>.Success(new FaviconCommandResponse
        {
            Photo = logo.Path
        });
    }
}