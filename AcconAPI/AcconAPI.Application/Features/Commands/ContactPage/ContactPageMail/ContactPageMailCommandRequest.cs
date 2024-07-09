using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.ContactPage.ContactPageMail;

public class ContactPageMailCommandRequest : IRequest<ResponseModel<ContactPageMailCommandResponse>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
}