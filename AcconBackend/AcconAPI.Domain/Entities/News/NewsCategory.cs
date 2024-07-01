using AcconAPI.Domain.Common;

namespace AcconAPI.Domain.Entities.News;

public class NewsCategory:BaseEntity
{
    public string Title { get; set; }
    public ICollection<News> News { get; set; }
}