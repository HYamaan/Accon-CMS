using AcconAPI.Application.Features.Commands.ContactPage.ContactPageMail;

namespace AcconAPI.Application.Services;

public interface IMailService
{
    Task SendPasswordResetMailAsync(ContactPageMailCommandRequest request);
}