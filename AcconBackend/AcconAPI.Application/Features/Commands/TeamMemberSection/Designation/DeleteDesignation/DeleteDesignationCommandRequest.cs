using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TeamMemberSection.Designation.DeleteDesignation;

public class DeleteDesignationCommandRequest : IRequest<ResponseModel<DeleteDesignationCommandResponse>>
{
    public Guid Id { get; set; }
}