namespace AcconAPI.Domain.Entities.Page;

public class NewsPage : PageEntity
{
    public ICollection<News.News> News { get; set; }
}