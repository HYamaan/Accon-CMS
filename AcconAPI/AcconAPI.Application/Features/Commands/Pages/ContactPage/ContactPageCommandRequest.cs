using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Pages.ContactPage;

public class ContactPageCommandRequest:IRequest<ResponseModel<ContactPageCommandResponse>>
{
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}