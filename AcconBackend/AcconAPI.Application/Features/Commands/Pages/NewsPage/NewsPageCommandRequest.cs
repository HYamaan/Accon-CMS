using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Pages.NewsPage;

public class NewsPageCommandRequest:IRequest<ResponseModel<NewsPageCommandResponse>>
{
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
}