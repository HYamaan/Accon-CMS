using AcconAPI.Application.Features.Commands.Pages.AboutPage;
using AcconAPI.Application.Features.Commands.Pages.ContactPage;
using AcconAPI.Application.Features.Commands.Pages.FaqPage;
using AcconAPI.Application.Features.Commands.Pages.GalleryPage;
using AcconAPI.Application.Features.Commands.Pages.HomePage;
using AcconAPI.Application.Features.Commands.Pages.NewsPage;
using AcconAPI.Application.Features.Commands.Pages.PortfolioPage;
using AcconAPI.Application.Features.Commands.Pages.PrivacyPage;
using AcconAPI.Application.Features.Commands.Pages.TermsPage;
using AcconAPI.Application.Features.Commands.Pages.TestimonialPage;
using AcconAPI.Application.Features.Queries.Menu;
using AcconAPI.Application.Features.Queries.Page;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPagesInformation()
        {
            GetPageQueryRequest request = new GetPageQueryRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGalleryPage(GalleryPageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePortfolioPage(PortfolioPageCommandRequest request)
        {

            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateHomePage(HomePageCommandRequest request)
        {

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAboutPage([FromForm] AboutPageCommandRequest request)
        {
            try
            {
                if (request.Photo != null)
                {
                    request.Photo = Request.Form.Files[0];
                }

                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateContactPage(ContactPageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFaqPage(FaqPageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> UpdateNewsPage(NewsPageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTermsPage(TermsPageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePrivacyPage(PrivacyPageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTestimonialPage(TestimonialPageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }

}
