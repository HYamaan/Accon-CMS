using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.News;

namespace AcconAPI.Domain.Entities.News;

public class News : BaseEntity
{
    public  string Title { get; set; }
    public string ShortContent { get; set; }

    public string Content { get; set; }
    public NewsCategory NewsCategory { get; set; }

    public NewsPhoto Photo { get; set; }
    public NewsBanner Banner { get; set; }

    public SeoItems SeoItems { get; set; }
}