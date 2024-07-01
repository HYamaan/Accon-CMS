using AcconAPI.Application.Features.Commands.WhyChooseUs.DeleteWhyChooseUs;
using AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUs;
using AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUsMainBackground;
using AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUsMainPhoto;
using AcconAPI.Application.Features.Queries.WhyChoose.GetAllWhyChoose;
using AcconAPI.Application.Features.Queries.WhyChoose.GetEditWhyChoose;
using AcconAPI.Application.Features.Queries.WhyChoose.GetWhyChooseBackgroundPhoto;
using AcconAPI.Application.Features.Queries.WhyChoose.GetWhyChooseMainPhoto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhyChooseUsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WhyChooseUsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditWhyChoose([FromQuery] GetEditWhyChooseQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWhyChooseList([FromQuery] GetAllWhyChooseQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetMainImage([FromQuery] GetWhyChooseMainPhotoQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBackgroundImage([FromQuery] GetWhyChooseBackgroundPhotoQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateChooseUs([FromForm] UpdateWhyChooseUsCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateMainPhoto([FromForm] UpdateWhyChooseUsMainPhotoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateBackgroundPhoto([FromForm] UpdateWhyChooseUsMainBackgroundRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteChooseUs([FromQuery] DeleteWhyChooseUsCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
