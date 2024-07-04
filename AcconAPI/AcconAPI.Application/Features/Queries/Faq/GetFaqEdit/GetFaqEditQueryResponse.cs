using AcconAPI.Domain.Enum;

namespace AcconAPI.Application.Features.Queries.Faq.GetFaqEdit;

public class GetFaqEditQueryResponse
{
    public string Title { get; set; }
    public string Content { get; set; }
    public VisiblePlace VisiblePage { get; set; }
}