using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AcconAPI.Domain.Enum;

namespace AcconAPI.Domain.Entities.Faq;

public class Faq:BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public VisiblePlace VisiblePage { get; set; }

    public FaqPage FaqPage { get; set; }
}