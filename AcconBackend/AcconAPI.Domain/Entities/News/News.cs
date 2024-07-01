using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.News;
using AcconAPI.Domain.Entities.Page;

namespace AcconAPI.Domain.Entities.News;

public class News : BaseEntity
{
    public  string Title { get; set; }
    public string ShortContent { get; set; }

    public string Content { get; set; }

    public Guid NewsCategoryId { get; set; }
    public NewsCategory NewsCategory { get; set; }
    public bool CommentShow { get; set; }
    public DateTime PublishDate { get; set; }
    public NewsPhoto Photo { get; set; }
    public NewsBanner Banner { get; set; }

    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }

    public Guid NewsPageId { get; set; }
    public NewsPage NewsPage { get; set; }
}