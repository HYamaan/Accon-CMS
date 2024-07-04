using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.WhyChoose.GetEditWhyChoose;

public class GetEditWhyChooseQueryRequest : IRequest<ResponseModel<GetEditWhyChooseQueryResponse>>
{
    public Guid Id { get; set; }
}