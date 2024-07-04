using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Partner.DeletePartner;

public class DeletePartnerCommandRequest : IRequest<ResponseModel<DeletePartnerCommandResponse>>
{
    public Guid Id { get; set; }
}