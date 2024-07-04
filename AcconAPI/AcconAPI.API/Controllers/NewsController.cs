using AcconAPI.Application.Features.Commands.NewsSection.DeleteNews;
using AcconAPI.Application.Features.Commands.NewsSection.DeleteNewsCategory;
using AcconAPI.Application.Features.Commands.NewsSection.NewsCategory;
using AcconAPI.Application.Features.Commands.NewsSection.UpdateNews;
using AcconAPI.Application.Features.Commands.Pages.NewsPage;
using AcconAPI.Application.Features.Queries.NewsSection.GetAllNews;
using AcconAPI.Application.Features.Queries.NewsSection.GetAllNewsCategory;
using AcconAPI.Application.Features.Queries.NewsSection.GetEditNews;
using AcconAPI.Application.Features.Queries.NewsSection.GetEditNewsCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllNewsCategory()
        {
            var result = await _mediator.Send(new GetAllNewsCategoryQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditNewsCategory([FromQuery] GetEditNewsCategoryQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateNewsCategory([FromBody] UpdateNewsCategoryCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteNewsCategory([FromQuery] DeleteNewsCategoryCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateNews([FromForm] UpdateNewsCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllNews([FromQuery] GetAllNewsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditNews([FromQuery] GetEditNewsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteNews([FromQuery] DeleteNewsCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
