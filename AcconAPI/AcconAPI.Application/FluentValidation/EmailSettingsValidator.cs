using AcconAPI.Application.Features.Commands.Settings.EmailSettings;
using AcconAPI.Domain.Entities;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class EmailSettingsValidator : AbstractValidator<EmailSettingsCommandRequest>
{
    public EmailSettingsValidator()
    {
        RuleFor(x => x.FromEmail)
            .NotEmpty().WithMessage("FromEmail cannot be empty")
            .EmailAddress().WithMessage("FromEmail must be a valid email address");

        RuleFor(x => x.ToEmail)
            .NotEmpty().WithMessage("ToEmail cannot be empty")
            .EmailAddress().WithMessage("ToEmail must be a valid email address");

        RuleFor(x => x.SmtpHost)
            .NotEmpty().WithMessage("SmtpHost cannot be empty");

        RuleFor(x => x.SmtpPort)
            .GreaterThan(0).WithMessage("SmtpPort must be greater than 0");

        RuleFor(x => x.SmtpUser)
            .NotEmpty().WithMessage("SmtpUser cannot be empty");

        RuleFor(x => x.SmtpPassword)
            .NotEmpty().WithMessage("SmtpPassword cannot be empty");
    }
}