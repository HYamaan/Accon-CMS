using AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.DeleteTestimonial;
using AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.UpdateTestimonial;
using AcconAPI.Application.Features.Commands.TestimonialSection.TestimonialMainPhoto;
using AcconAPI.Application.Features.Queries.Testimonal.GetAllTestimonal;
using AcconAPI.Application.Features.Queries.Testimonal.GetEditTestimonal;
using AcconAPI.Application.Features.Queries.TestimonialMainPhoto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditTestimonial([FromQuery] GetEditTestimonalQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTestimonials([FromQuery] GetAllTestimonalQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTestimonial([FromForm] UpdateTestimonialCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTestimonial([FromQuery] DeleteTestimonialCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> TestimonialMainPhoto([FromForm] TestimonialMainPhotoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTestimonialMainPhoto(
            [FromQuery] GetTestimonialMainPhotoQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
