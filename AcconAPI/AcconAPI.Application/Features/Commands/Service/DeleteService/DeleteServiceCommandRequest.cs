using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Service.DeleteService;

public class DeleteServiceCommandRequest : IRequest<ResponseModel<DeleteServiceCommandResponse>>
{
    public Guid Id { get; set; }
}