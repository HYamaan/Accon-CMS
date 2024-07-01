using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Testimonal.GetEditTestimonal;

public class GetEditTestimonalQueryRequest : IRequest<ResponseModel<GetEditTestimonalQueryResponse>>
{
    public Guid Id { get; set; }

}