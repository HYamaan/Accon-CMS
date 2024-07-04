using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Languages;

public class GetAllLanguagesQueryRequest : IRequest<ResponseModel<GetAllLanguagesQueryResponse>>
{
    
}