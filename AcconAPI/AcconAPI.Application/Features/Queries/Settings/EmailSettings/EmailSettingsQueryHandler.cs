using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Settings.EmailSettings;

public class EmailSettingsQueryHandler:IRequestHandler<EmailSettingsQueryRequest,ResponseModel<EmailSettingsQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.EmailSettings> _emailSettingsRepository;

    public EmailSettingsQueryHandler(IGenericRepository<Domain.Entities.Settings.EmailSettings> emailSettingsRepository)
    {
        _emailSettingsRepository = emailSettingsRepository;
    }

    public async Task<ResponseModel<EmailSettingsQueryResponse>> Handle(EmailSettingsQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _emailSettingsRepository.GetAll().FirstOrDefaultAsync();

        if (result == null)
        {
            return ResponseModel<EmailSettingsQueryResponse>.Fail("No Email Settings Found");
        }

        return ResponseModel<EmailSettingsQueryResponse>.Success(new EmailSettingsQueryResponse
        {
            EmailFrom = result.FromEmail,
            EmailTo = result.ToEmail,
            SmptPort = result.SmtpPort,
            SmptHost = result.SmtpHost,
            SmptUser = result.SmtpUser,
            SmptPassword = result.SmtpPassword
        });
    }
}