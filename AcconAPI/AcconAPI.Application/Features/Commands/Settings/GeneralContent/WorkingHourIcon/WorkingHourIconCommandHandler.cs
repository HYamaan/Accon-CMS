using AcconAPI.Application.Features.Commands.Settings.GeneralContent.PhoneIcon;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.WorkingHour;

public class WorkingHourIconCommandHandler:IRequestHandler<WorkingHourIconCommandRequest,ResponseModel<WorkingHourIconCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.FooterWorkingIcon> _workingIconRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    public WorkingHourIconCommandHandler(IGenericRepository<FooterWorkingIcon> workingIconRepository, IStorageService storageService, IFileCheckHelper fileCheckHelper)
    {
        _workingIconRepository = workingIconRepository;
        _storageService = storageService;
        _fileCheckHelper = fileCheckHelper;
    }

    public async Task<ResponseModel<WorkingHourIconCommandResponse>> Handle(WorkingHourIconCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Photo == null)
            return ResponseModel<WorkingHourIconCommandResponse>.Fail("Photo is required");

        if (!await _fileCheckHelper.CheckImageFormat(request.Photo))
            return ResponseModel<WorkingHourIconCommandResponse>.Fail("Photo is not an image");

        var setStorage = await _storageService.UploadAsync("files", request.Photo);

        var logo = new Domain.Entities.File.Settings.FooterWorkingIcon()
        {
            Path = setStorage.pathOrContainerName,
            FileName = setStorage.fileName,
            Storage = _storageService.StorageName
        };
        var result = await _workingIconRepository.AddAsync(logo);
        if (result == null)
            return ResponseModel<WorkingHourIconCommandResponse>.Fail("Failed to save logo");
        await _workingIconRepository.SaveAsync();

        return ResponseModel<WorkingHourIconCommandResponse>.Success(new WorkingHourIconCommandResponse
        {
            Photo = logo.Path
        });
    }
}