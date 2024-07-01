using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Partner.GetEditPartner;

public class GetEditPartnerCommandRequest : IRequest<ResponseModel<GetEditPartnerCommandResponse>>
{
    public Guid Id { get; set; }
}