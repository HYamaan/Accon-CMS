using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetAllNews;

public class GetAllNewsQueryRequest : IRequest<ResponseModel<GetAllNewsQueryResponse>>
{
    
}