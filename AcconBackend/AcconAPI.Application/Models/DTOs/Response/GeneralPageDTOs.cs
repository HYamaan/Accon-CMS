using AcconAPI.Domain.Entities.File;

namespace AcconAPI.Application.Models.DTOs.Response;

public class GeneralPageDTOs
{
    public Guid Id { get; set; }
    public string Page { get; set; }
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}

public class AboutPageDto : GeneralPageDTOs
{
    public string Path { get; set; }
    public string Content { get; set; }
    public string MissionHeading { get; set; }
    public string MissionContent { get; set; }
    public string VisionHeading { get; set; }
    public string VisionContent { get; set; }
}