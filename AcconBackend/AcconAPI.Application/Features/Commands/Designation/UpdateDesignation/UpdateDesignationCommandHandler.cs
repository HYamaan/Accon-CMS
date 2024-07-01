using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using FluentValidation;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Designation.UpdateDesignation;

public class UpdateDesignationCommandHandler : IRequestHandler<UpdateDesignationCommandRequest, ResponseModel<UpdateDesignationCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.Designation> _designationRepository;
    private IValidator<UpdateDesignationCommandRequest> _validator;


    public UpdateDesignationCommandHandler(IGenericRepository<Domain.Entities.TeamMember.Designation> designationRepository, IValidator<UpdateDesignationCommandRequest> validator)
    {
        _designationRepository = designationRepository;
        _validator = validator;
    }

    public async Task<ResponseModel<UpdateDesignationCommandResponse>> Handle(UpdateDesignationCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<UpdateDesignationCommandResponse>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        if (request.Id == null)
        {
            var designationEntity = new Domain.Entities.TeamMember.Designation
            {
                Title = request.Title
            };
            await _designationRepository.AddAsync(designationEntity);

        }
        else
        {
            var designation = await _designationRepository.GetByIdAsync(request.Id.ToString());
            if (designation == null)
            {
                return ResponseModel<UpdateDesignationCommandResponse>.Fail("Designation not found");
            }
            designation.Title = request.Title;
            _designationRepository.Update(designation);
        }
        await _designationRepository.SaveAsync();
        return ResponseModel<UpdateDesignationCommandResponse>.Success();
    }
}