using AcconAPI.Application.Features.Commands.SocialMedia;
using AcconAPI.Application.Features.Queries.SocialMedia;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateSocial([FromBody] UpdateSocialMediaCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSocial()
        {
            var result = await _mediator.Send(new GetAllSocialMediaQueryRequest());
            return Ok(result);
        }
    }
}
