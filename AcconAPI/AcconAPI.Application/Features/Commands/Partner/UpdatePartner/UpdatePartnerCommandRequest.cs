using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Partner.UpdatePartner;

public class UpdatePartnerCommandRequest : IRequest<ResponseModel<UpdatePartnerCommandResponse>>
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public IFormFile Photo { get; set; }
}