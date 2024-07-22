using AcconAPI.Application.Features.Commands.ContactPage.ContactPageMail;
using AcconAPI.Application.Features.Queries.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("contact")]
        public async Task<IActionResult> ContactPageMail([FromBody] ContactPageMailCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDashboard()
        {
            var response = await _mediator.Send(new GetDashboardQueryRequest());
            return Ok(response);
        }
    }
}
