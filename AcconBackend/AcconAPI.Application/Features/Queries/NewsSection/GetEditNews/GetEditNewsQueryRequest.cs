using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetEditNews;

public class GetEditNewsQueryRequest : IRequest<ResponseModel<GetEditNewsQueryResponse>>
{
    public Guid Id { get; set; }
}