using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.SocialMedia;

public class SocialMedia:BaseEntity
{
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string Instagram { get; set; }
    public string LinkedIn { get; set; }
    public string googlePlus { get; set; }
    public string Youtube { get; set; }
    public string Pinterest { get; set; }
    public string TikTok { get; set; }
    public string Snapchat { get; set; }
    public string WhatsApp { get; set; }
    public string Telegram { get; set; }
    
}