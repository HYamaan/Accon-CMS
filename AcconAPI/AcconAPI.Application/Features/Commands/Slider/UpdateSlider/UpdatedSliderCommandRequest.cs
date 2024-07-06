using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Slider.UpdateSlider;

public class UpdatedSliderCommandRequest : IRequest<ResponseModel<UpdatedSliderCommandResponse>>
{
    public Guid? Id { get; set; }
    public IFormFile? Photo { get; set; }
    public string Heading { get; set; }
    public string Content { get; set; }
    public string Button1Text { get; set; }
    public string Button1Link { get; set; }
    public string Button2Text { get; set; }
    public string Button2Link { get; set; }

}