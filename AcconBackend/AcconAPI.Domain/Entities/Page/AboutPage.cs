using AcconAPI.Domain.Entities.File;

namespace AcconAPI.Domain.Entities.Page;

public class AboutPage:PageEntity
{
    public AboutPagePhoto Photo { get; set; }
    public string Content { get; set; }
    public string MissionHeading { get; set; }
    public string MissionContent { get; set; }
    public string VisionHeading { get; set; }
    public string VisionContent { get; set; }
}