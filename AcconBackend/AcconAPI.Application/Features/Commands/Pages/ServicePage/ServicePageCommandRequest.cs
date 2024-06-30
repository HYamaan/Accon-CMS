using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Pages.ServicePage;

public class ServicePageCommandRequest:IRequest<ResponseModel<ServicePageCommandResponse>>
{
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}