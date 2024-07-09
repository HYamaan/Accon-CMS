namespace AcconAPI.Application.Features.Queries.Pages.AboutPage;

public class AboutPageQueryResponse
{
    public string Photo { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public string MissionTitle { get; set; }
    public string MissionContent { get; set; }
    public string VisionTitle { get; set; }
    public string VisionContent { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}