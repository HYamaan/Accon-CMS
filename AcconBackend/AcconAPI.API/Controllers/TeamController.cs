using AcconAPI.Application.Features.Commands.Designation.DeleteDesignation;
using AcconAPI.Application.Features.Commands.Designation.UpdateDesignation;
using AcconAPI.Application.Features.Commands.TeamMember.DeleteTeamMember;
using AcconAPI.Application.Features.Commands.TeamMember.UpdateTeamMember;
using AcconAPI.Application.Features.Queries.Designation.GetAllDesignation;
using AcconAPI.Application.Features.Queries.Designation.GetEditDesignation;
using AcconAPI.Application.Features.Queries.TeamMember.GetAllTeamMember;
using AcconAPI.Application.Features.Queries.TeamMember.GetEditTeamMember;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDesignation([FromQuery]GetAllDesignationQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditDesignation([FromQuery] GetEditDesignationQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateDesignation([FromBody] UpdateDesignationCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDesignation([FromQuery] DeleteDesignationCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTeamMember([FromQuery] GetAllTeamMemberQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditTeamMember([FromQuery] GetEditTeamMemberQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTeamMember([FromForm] UpdateTeamMemberCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTeamMember([FromQuery] DeleteTeamMemberCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
