using AcconAPI.Application.Features.Commands.PhotoGallery.DeleteGallery;
using AcconAPI.Application.Features.Commands.PhotoGallery.UpdateGallery;
using AcconAPI.Application.Features.Queries.PhotoGallery.GetAllPhotoGallery;
using AcconAPI.Application.Features.Queries.PhotoGallery.GetEditPhotoGallery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GalleryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllGallery([FromQuery]GetAllPhotoGalleryQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditGallery([FromQuery] GetEditPhotoGalleryQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGallery([FromForm] UpdateGalleryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGallery([FromQuery] DeleteGalleryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }



    }
}
