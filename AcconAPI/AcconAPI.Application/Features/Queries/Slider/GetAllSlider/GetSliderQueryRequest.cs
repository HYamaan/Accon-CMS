using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Slider.GetAllSlider;

public class GetSliderQueryRequest : IRequest<ResponseModel<GetSliderQueryResponse>>
{

}