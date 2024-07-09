using AcconAPI.Application.Services;
using AcconAPI.Domain.Common;
using FluentValidation;
using MediatR;

namespace AcconAPI.Application.Features.Commands.ContactPage.ContactPageMail;

public class ContactPageMailCommandHandler : IRequestHandler<ContactPageMailCommandRequest, ResponseModel<ContactPageMailCommandResponse>>
{
    private readonly IMailService _mailService;
    private readonly IValidator<ContactPageMailCommandRequest> _validator;

    public ContactPageMailCommandHandler(IMailService mailService, IValidator<ContactPageMailCommandRequest> validator)
    {
        _mailService = mailService;
        _validator = validator;
    }

    public async Task<ResponseModel<ContactPageMailCommandResponse>> Handle(ContactPageMailCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<ContactPageMailCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

        try
        {
            await _mailService.SendPasswordResetMailAsync(request);
            return ResponseModel<ContactPageMailCommandResponse>.Success("Mail sent successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<ContactPageMailCommandResponse>.Fail(e.Message);
        }
    }
}