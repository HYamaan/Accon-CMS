using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.Page;

public class PageEntity : BaseEntity
{
    public bool IsPublished { get; set; }
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}