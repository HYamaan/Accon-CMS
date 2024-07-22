using AcconAPI.Application.Features.Commands.Settings.EmailSettings;
using AcconAPI.Application.Features.Commands.Settings.Favicon;
using AcconAPI.Application.Features.Commands.Settings.GeneralContent.AddressIcon;
using AcconAPI.Application.Features.Commands.Settings.GeneralContent.GeneralInformation;
using AcconAPI.Application.Features.Commands.Settings.GeneralContent.PhoneIcon;
using AcconAPI.Application.Features.Commands.Settings.GeneralContent.WorkingHour;
using AcconAPI.Application.Features.Commands.Settings.HomePageSettings;
using AcconAPI.Application.Features.Commands.Settings.LoginBackground;
using AcconAPI.Application.Features.Commands.Settings.Logo.AdminLogo;
using AcconAPI.Application.Features.Commands.Settings.Logo.WebsiteLogo;
using AcconAPI.Application.Features.Commands.Settings.SideFooter;
using AcconAPI.Application.Features.Queries.Settings.EmailSettings;
using AcconAPI.Application.Features.Queries.Settings.Favicon;
using AcconAPI.Application.Features.Queries.Settings.GeneralContent;
using AcconAPI.Application.Features.Queries.Settings.HomePageSettings;
using AcconAPI.Application.Features.Queries.Settings.LoginBackground;
using AcconAPI.Application.Features.Queries.Settings.Logo;
using AcconAPI.Application.Features.Queries.Settings.SideFooter;
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
        public async Task<IActionResult> UpdateWebsiteLogo([FromForm] WebsiteLogoCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAdminLogo([FromForm] AdminLogoCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFavicon([FromForm] FaviconCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateBackgroundLogo([FromForm] LoginBackgroundCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAdressIcon([FromForm] AddressIconCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePhoneIcon([FromForm] PhoneIconCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateWorkingHourIcon([FromForm] WorkingHourIconCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGeneralContent([FromBody] GeneralContentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFooterSideBar([FromBody] SideFooterCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateHomePageSettings([FromBody] HomePageSettingsCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetHomePageSettingsImage([FromForm] HomePageSettingsCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateEmailSettings([FromBody] EmailSettingsCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetLogoSettings()
        {

            var result = await _mediator.Send(new LogoQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFaviconSettings()
        {
            var result = await _mediator.Send(new FaviconQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLoginBackgroundSettings()
        {
            var result = await _mediator.Send(new LoginBackgroundQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetGeneralContentSettings()
        {
            var result = await _mediator.Send(new GeneralContentQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmailSettings()
        {
            var result = await _mediator.Send(new EmailSettingsQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSideFooterSettings()
        {
            var result = await _mediator.Send(new SideFooterQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetHomePageSettings()
        {
            var result = await _mediator.Send(new HomePageSettingsQueryRequest());
            return Ok(result);
        }


    }
}
