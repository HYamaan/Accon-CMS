using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities;

public class EmailSettings:BaseEntity
{
    public string FromEmail { get; set; }
    public string ToEmail { get; set; }
    public string SmtpHost { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; }
    public string SmtpPassword { get; set; }
}