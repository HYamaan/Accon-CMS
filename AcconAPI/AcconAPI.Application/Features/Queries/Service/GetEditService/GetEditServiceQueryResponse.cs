namespace AcconAPI.Application.Features.Queries.Service.GetEditService;

public class GetEditServiceQueryResponse
{
    public Guid Id { get; set; }
    public string Heading { get; set; }
    public string ShortContent { get; set; }
    public string Content { get; set; }
    public string Photo { get; set; }
    public string Banner { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
        
}