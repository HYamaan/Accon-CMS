using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TeamMember.UpdateTeamMember;

public class UpdateTeamMemberCommandHandler : IRequestHandler<UpdateTeamMemberCommandRequest, ResponseModel<UpdateTeamMemberCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.TeamMember> _teamMemberRepository;
    private readonly IGenericRepository<TeamMemberPhoto> _teamMemberPhotoRepository;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    private readonly ICreateTeamMemberCommandRequestValidator _createValidator;
    private readonly IUpdateTeamMemberCommandRequestValidator _updateValidator;

    public UpdateTeamMemberCommandHandler(IGenericRepository<Domain.Entities.TeamMember.TeamMember> teamMemberRepository, IStorageService storageService, IFileCheckHelper fileCheckHelper, ICreateTeamMemberCommandRequestValidator createValidator, IUpdateTeamMemberCommandRequestValidator updateValidator, IGenericRepository<TeamMemberPhoto> teamMemberPhotoRepository)
    {
        _teamMemberRepository = teamMemberRepository;
        _storageService = storageService;
        _fileCheckHelper = fileCheckHelper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _teamMemberPhotoRepository = teamMemberPhotoRepository;
    }

    public async Task<ResponseModel<UpdateTeamMemberCommandResponse>> Handle(UpdateTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {

        if (request.Id == null)
        {
            return await CreateTeamMember(request, cancellationToken);
        }
        return await UpdateTeamMember(request, cancellationToken);
    }
    private async Task<ResponseModel<UpdateTeamMemberCommandResponse>> CreateTeamMember(UpdateTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<UpdateTeamMemberCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            if (!await _fileCheckHelper.CheckImageFormat(request.Image))
            {
                return ResponseModel<UpdateTeamMemberCommandResponse>.Fail("Invalid image format");
            }


            await _teamMemberRepository.BeginTransactionAsync();
            var teamPhoto = await _storageService.UploadAsync("files", request.Image);
            var teamPhotoModel = new TeamMemberPhoto
            {
                Path = teamPhoto.pathOrContainerName,
                FileName = teamPhoto.fileName,
                Storage = _storageService.StorageName
            };
            await _teamMemberPhotoRepository.AddAsync(teamPhotoModel);
            await _teamMemberRepository.CommitTransactionAsync();

            var teamMember = new Domain.Entities.TeamMember.TeamMember()
            {
                DesignationId = request.Designation,
                Facebook = request.Facebook,
                LinkedIn = request.LinkedIn,
                Name = request.Title,
                Photo = teamPhotoModel,
                Twitter = request.Twitter,
                Youtube = request.Youtube

            };
            await _teamMemberRepository.AddAsync(teamMember);
            await _teamMemberPhotoRepository.SaveAsync();
            return ResponseModel<UpdateTeamMemberCommandResponse>.Success();

        }
        catch (Exception e)
        {
            return ResponseModel<UpdateTeamMemberCommandResponse>.Fail(e.Message);
        }

    }
    private async Task<ResponseModel<UpdateTeamMemberCommandResponse>> UpdateTeamMember(UpdateTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseModel<UpdateTeamMemberCommandResponse>.Fail(validationResult.Errors
                    .Select(e => e.ErrorMessage).ToList());
            }

            await _teamMemberRepository.BeginTransactionAsync();
            var teamMember = await _teamMemberRepository.GetByIdAsync(request.Id.ToString());
            if (teamMember == null)
            {
                return ResponseModel<UpdateTeamMemberCommandResponse>.Fail("Team member not found");
            }

            if ((request.Image != null) && (!await _fileCheckHelper.CheckImageFormat(request.Image)))
            {

                var teamMemberPhoto = await _storageService.UploadAsync("files", request.Image);
                var teamMemberPhotoModel = new TeamMemberPhoto
                {
                    Path = teamMemberPhoto.pathOrContainerName,
                    FileName = teamMemberPhoto.fileName,
                    Storage = _storageService.StorageName
                };
                await _teamMemberPhotoRepository.AddAsync(teamMemberPhotoModel);
                await _teamMemberPhotoRepository.SaveAsync();

                teamMember.Photo = teamMemberPhotoModel;
            }

            if (teamMember.Name != request.Title)
            {
                teamMember.Name = request.Title;
            }

            if (teamMember.DesignationId != request.Designation)
            {
                teamMember.DesignationId = request.Designation;
            }

            if (teamMember.Facebook != request.Facebook)
            {
                teamMember.Facebook = request.Facebook;
            }

            if (teamMember.LinkedIn != request.LinkedIn)
            {
                teamMember.LinkedIn = request.LinkedIn;
            }

            if (teamMember.Twitter != request.Twitter)
            {
                teamMember.Twitter = request.Twitter;
            }

            if (teamMember.Youtube != request.Youtube)
            {
                teamMember.Youtube = request.Youtube;
            }

            _teamMemberRepository.Update(teamMember);
            await _teamMemberRepository.CommitTransactionAsync();
            await _teamMemberRepository.SaveAsync();
            return ResponseModel<UpdateTeamMemberCommandResponse>.Success();
        }
        catch (Exception e)
        {
           await _teamMemberRepository.RollbackTransactionAsync();
           return ResponseModel<UpdateTeamMemberCommandResponse>.Fail(e.Message);

        }

    }
}