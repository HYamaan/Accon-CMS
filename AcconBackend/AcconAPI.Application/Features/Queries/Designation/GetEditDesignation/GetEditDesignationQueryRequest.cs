using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Designation.GetEditDesignation;

public class GetEditDesignationQueryRequest : IRequest<ResponseModel<GetEditDesignationQueryResponse>>
{
    public Guid Id { get; set; }
}