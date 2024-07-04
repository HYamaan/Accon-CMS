using AcconAPI.Application.Features.Commands.Partner.DeletePartner;
using AcconAPI.Application.Features.Commands.Partner.UpdatePartner;
using AcconAPI.Application.Features.Queries.Partner.GetAllPartner;
using AcconAPI.Application.Features.Queries.Partner.GetEditPartner;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPartner([FromQuery]GetAllPartnerCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditPartner([FromQuery]GetEditPartnerCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePartner([FromForm]UpdatePartnerCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePartner([FromQuery] DeletePartnerCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
