using AcconAPI.Application.Features.Commands.Language;
using AcconAPI.Application.Features.Queries.Languages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateLanguage([FromBody] UpdateLanguageCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await _mediator.Send(new GetAllLanguagesQueryRequest());
            return Ok(result);
        }
    }
}
