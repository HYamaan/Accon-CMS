using AcconAPI.Application.Features.Commands.Service.UpdateService;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Settings.EmailSettings;

public class EmailSettingsCommandHandler:IRequestHandler<EmailSettingsCommandRequest,ResponseModel<EmailSettingsCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.EmailSettings> _emailSettingsRepository;
    private readonly IValidator<EmailSettingsCommandRequest> _validator;

    public EmailSettingsCommandHandler(IGenericRepository<Domain.Entities.Settings.EmailSettings> emailSettingsRepository, IValidator<EmailSettingsCommandRequest> validator)
    {
        _emailSettingsRepository = emailSettingsRepository;
        _validator = validator;
    }

    public async Task<ResponseModel<EmailSettingsCommandResponse>> Handle(EmailSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<EmailSettingsCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

        var result= await _emailSettingsRepository.GetAll().FirstOrDefaultAsync();
        if (result == null)
        {
            var emailSettings = new Domain.Entities.Settings.EmailSettings
            {
                FromEmail = request.FromEmail,
                ToEmail = request.ToEmail,
                SmtpHost = request.SmtpHost,
                SmtpPort = request.SmtpPort,
                SmtpUser = request.SmtpUser,
                SmtpPassword = request.SmtpPassword
            };
            await _emailSettingsRepository.AddAsync(emailSettings);
        }
        else
        {
            result.FromEmail = request.FromEmail;
            result.ToEmail = request.ToEmail;
            result.SmtpHost = request.SmtpHost;
            result.SmtpPort = request.SmtpPort;
            result.SmtpUser = request.SmtpUser;
            result.SmtpPassword = request.SmtpPassword;
             _emailSettingsRepository.Update(result);
        }
        await _emailSettingsRepository.SaveAsync();
        return ResponseModel<EmailSettingsCommandResponse>.Success();
    }
}