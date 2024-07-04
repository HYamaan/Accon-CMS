using AcconAPI.Application.Features.Commands.Faq.DeleteFaq;
using AcconAPI.Application.Features.Commands.Faq.UpdateFaq;
using AcconAPI.Application.Features.Commands.Faq.UpdateFaqMainPhoto;
using AcconAPI.Application.Features.Queries.Faq.GetAllFaq;
using AcconAPI.Application.Features.Queries.Faq.GetFaqEdit;
using AcconAPI.Application.Features.Queries.Faq.GetFaqMainPhoto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FaqController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFaq([FromQuery]GetAllFaqQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFaqEdit([FromQuery]GetFaqEditQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFaq([FromBody]FaqCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteFaq([FromQuery] DeleteFaqCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFaqMainPhoto([FromForm] UpdateFaqMainPhotoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFaqMainPhoto([FromQuery] GetFaqMainPhotoQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
