using AcconAPI.Application.Features.Commands.Pages.PortfolioPage;
using AcconAPI.Application.Features.Commands.PortfolioCategory.DeletePortfolioCategory;
using AcconAPI.Application.Features.Commands.PortfolioCategory.EditPortfolioCategory;
using AcconAPI.Application.Features.Queries.PortfolioCategory.GetAllPortfolioCategory;
using AcconAPI.Application.Features.Queries.PortfolioCategory.GetEditPortfolioCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPortfolioCategory([FromQuery] GetAllPortfolioCategoryQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditPortfolioCategory([FromQuery] GetEditPortfolioCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult>  AddPortfolioCategory([FromBody] EditPortfolioCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePortfolioCategory([FromQuery] DeletePortfolioCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
