using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Pages.NewsPage;

public class NewsPageQueryRequest : IRequest<ResponseModel<NewsPageQueryResponse>>
{
    
}