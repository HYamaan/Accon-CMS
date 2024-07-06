using AcconAPI.Application.Features.Commands.Service.DeleteService;
using AcconAPI.Application.Features.Commands.Service.UpdateService;
using AcconAPI.Application.Features.Commands.Slider;
using AcconAPI.Application.Features.Queries.Service.GetAllService;
using AcconAPI.Application.Features.Queries.Service.GetEditService;
using AcconAPI.Application.Features.Queries.Slider.GetAllSlider;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetServiceEdit([FromQuery]GetEditServiceQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllService([FromQuery]GetAllServiceQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateService([FromForm] UpdateServiceCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteService([FromQuery] DeleteServiceCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
