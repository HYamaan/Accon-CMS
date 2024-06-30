using AcconAPI.Application.Features.Commands.Menu;
using AcconAPI.Application.Features.Commands.Pages.ServicePage;
using AcconAPI.Application.Features.Queries.Menu;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetPageInformation()
        {
            GetMenuQueryRequest request = new GetMenuQueryRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateMenuInformation(UpdateMenuCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateServicePage(ServicePageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
