using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetEditNewsCategory;

public class GetEditNewsCategoryQueryRequest : IRequest<ResponseModel<GetEditNewsCategoryQueryResponse>>
{
    public Guid Id { get; set; }
}