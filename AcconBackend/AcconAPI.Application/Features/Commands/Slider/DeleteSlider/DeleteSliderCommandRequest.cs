using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Slider.DeleteSlider;

public class DeleteSliderCommandRequest : IRequest<ResponseModel<DeleteSliderCommandResponse>>
{
    public Guid Id { get; set; }
}