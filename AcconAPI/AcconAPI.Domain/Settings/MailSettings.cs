using Microsoft.Extensions.Configuration;

namespace AcconAPI.Domain.Settings;

public class MailSettings
{
    [ConfigurationKeyName("Mail")]
    public string EmailTo { get; set; }
    [ConfigurationKeyName("Host")]
    public string SmtpHost { get; set; }
    [ConfigurationKeyName("Port")]
    public int SmtpPort { get; set; }
    [ConfigurationKeyName("DisplayName")]
    public string SmtpUser { get; set; }
    [ConfigurationKeyName("Password")]
    public string SmtpPass { get; set; }
}