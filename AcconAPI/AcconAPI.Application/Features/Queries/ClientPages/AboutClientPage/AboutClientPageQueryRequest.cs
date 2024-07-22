using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.ClientPages.AboutPage;

public class AboutClientPageQueryRequest : IRequest<ResponseModel<AboutClientPageQueryResponse>>
{
    
}