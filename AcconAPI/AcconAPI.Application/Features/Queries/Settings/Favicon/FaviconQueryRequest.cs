using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Settings.Favicon;

public class FaviconQueryRequest : IRequest<ResponseModel<FaviconQueryResponse>>
{
    
}