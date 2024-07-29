using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.ClientPages.NewsClientContentPage;

public class NewsClientContentPageQueryRequest : IRequest<ResponseModel<NewsClientContentPageQueryResponse>>
{
    public Guid Id { get; set; }
}