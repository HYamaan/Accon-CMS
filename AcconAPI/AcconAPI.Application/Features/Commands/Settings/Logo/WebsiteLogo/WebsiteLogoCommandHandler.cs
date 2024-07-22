using AcconAPI.Application.Features.Commands.Settings.Logo.AdminLogo;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.Logo.WebsiteLogo;

public class WebsiteLogoCommandHandler:IRequestHandler<WebsiteLogoCommandRequest,ResponseModel<WebsiteLogoCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.WebSiteLogo> _websiteLogoRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public WebsiteLogoCommandHandler(IFileCheckHelper fileCheckHelper, IStorageService storageService, IGenericRepository<WebSiteLogo> websiteLogoRepository)
    {
        _fileCheckHelper = fileCheckHelper;
        _storageService = storageService;
        _websiteLogoRepository = websiteLogoRepository;
    }

    public async Task<ResponseModel<WebsiteLogoCommandResponse>> Handle(WebsiteLogoCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Photo == null)
                return ResponseModel<WebsiteLogoCommandResponse>.Fail("Photo is required");

            if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
                return ResponseModel<WebsiteLogoCommandResponse>.Fail("Photo is not an image");

            var setStorage = await _storageService.UploadAsync("files", request.Photo);

            var logo = new WebSiteLogo()
            {
                Path = setStorage.pathOrContainerName,
                FileName = setStorage.fileName,
                Storage = _storageService.StorageName
            };
            var result = await _websiteLogoRepository.AddAsync(logo);

            await _websiteLogoRepository.SaveAsync();

            return ResponseModel<WebsiteLogoCommandResponse>.Success(new WebsiteLogoCommandResponse
            {
                Photo = logo.Path
            });
        }
        catch (Exception e)
        {
            return ResponseModel<WebsiteLogoCommandResponse>.Fail(e.Message);
        }
    }
}