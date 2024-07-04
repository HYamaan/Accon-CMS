using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Pages.FaqPage;

public class FaqPageCommandRequest:IRequest<ResponseModel<FaqPageCommandResponse>>
{
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}