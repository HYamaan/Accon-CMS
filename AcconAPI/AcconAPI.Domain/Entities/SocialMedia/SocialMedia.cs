using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.SocialMedia;

public class SocialMedia:BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    
}