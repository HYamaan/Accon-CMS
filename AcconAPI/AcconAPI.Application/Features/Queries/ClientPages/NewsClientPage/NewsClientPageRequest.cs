using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.ClientPages.NewsPage;

public class NewsClientPageRequest : IRequest<ResponseModel<NewsClientPageResponse>>
{
    
}