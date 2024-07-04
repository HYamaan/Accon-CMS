using AcconAPI.Application.Features.Commands.Slider.DeleteSlider;
using AcconAPI.Application.Features.Commands.Slider.UpdateSlider;
using AcconAPI.Application.Features.Queries.Slider;
using AcconAPI.Application.Features.Queries.Slider.GetAllSlider;
using AcconAPI.Application.Features.Queries.Slider.GetSliderEdit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SliderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSliderEdit([FromQuery]GetSliderEditQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSlider()
        {
            var response = await _mediator.Send(new GetSliderQueryRequest());
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateSlider([FromForm] UpdatedSliderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSlider([FromQuery] DeleteSliderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
