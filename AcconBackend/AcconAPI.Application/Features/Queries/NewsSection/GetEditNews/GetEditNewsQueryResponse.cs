namespace AcconAPI.Application.Features.Queries.NewsSection.GetEditNews;

public class GetEditNewsQueryResponse
{
    public Guid Id { get; set; }
    public string ShortContent { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }
    public bool CommentShow { get; set; }
    public string BannerPhoto { get; set; }
    public string FeaturePhoto { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeyword { get; set; }


}