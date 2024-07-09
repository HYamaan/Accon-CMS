using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Settings.EmailSettings;

public class EmailSettingsCommandRequest : IRequest<ResponseModel<EmailSettingsCommandResponse>>
{
    public string FromEmail { get; set; }
    public string ToEmail { get; set; }
    public string SmtpHost { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; }
    public string SmtpPassword { get; set; }
}