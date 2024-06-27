namespace AcconAPI.Domain.Entities.Page;

public class FaqPage:PageEntity
{
    public ICollection<Faq.Faq> Faqs { get; set; }
}