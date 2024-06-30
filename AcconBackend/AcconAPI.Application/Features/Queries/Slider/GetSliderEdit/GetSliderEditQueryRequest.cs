using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Slider.GetSliderEdit;

public class GetSliderEditQueryRequest : IRequest<ResponseModel<GetSliderEditQueryResponse>>
{
    public string Id { get; set; }
}