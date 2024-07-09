using AcconAPI.Application.Features.Commands.Settings.Logo.AdminLogo;
using AcconAPI.Application.Features.Commands.Settings.Logo.WebsiteLogo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAdminLogo([FromForm] AdminLogoCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateWebsiteLogo([FromForm] WebsiteLogoCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
