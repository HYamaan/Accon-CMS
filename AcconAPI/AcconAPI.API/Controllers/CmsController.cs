using AcconAPI.Application.Features.Commands.ContactPage.ContactPageMail;
using AcconAPI.Application.Features.Queries.ClientPages.AboutPage;
using AcconAPI.Application.Features.Queries.ClientPages.ContactPage;
using AcconAPI.Application.Features.Queries.ClientPages.FaqPage;
using AcconAPI.Application.Features.Queries.ClientPages.GalleryPage;
using AcconAPI.Application.Features.Queries.ClientPages.HomePage;
using AcconAPI.Application.Features.Queries.ClientPages.NewsClientContentPage;
using AcconAPI.Application.Features.Queries.ClientPages.NewsPage;
using AcconAPI.Application.Features.Queries.ClientPages.PrivacyPage;
using AcconAPI.Application.Features.Queries.ClientPages.ServiceClientContentPage;
using AcconAPI.Application.Features.Queries.ClientPages.ServicePage;
using AcconAPI.Application.Features.Queries.ClientPages.TermsPage;
using AcconAPI.Application.Features.Queries.ClientPages.TestimonialPage;
using AcconAPI.Application.Features.Queries.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcconAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("contact")]
        public async Task<IActionResult> ContactPageMail([FromBody] ContactPageMailCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDashboard()
        {
            var response = await _mediator.Send(new GetDashboardQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAboutPage()
        {
            var response = await _mediator.Send(new AboutClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetGalleryPage()
        {
            var response = await _mediator.Send(new GalleryClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFaqPage()
        {
            var response = await _mediator.Send(new FaqClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetServicePage()
        {
            var response = await _mediator.Send(new ServiceClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetServiceContentPage([FromQuery] ServiceClientContentPageQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTestimonialPage()
        {
            var response = await _mediator.Send(new TestimonialClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNewsPage()
        {
            var response = await _mediator.Send(new NewsClientPageRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNewsContentPage([FromQuery] NewsClientContentPageQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetContactPage()
        {
            var response = await _mediator.Send(new ContactClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPrivacyPage()
        {
            var response = await _mediator.Send(new PrivacyClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTermsPage()
        {
            var response = await _mediator.Send(new TermsClientPageQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetHomeClientPage()
        {
            var response = await _mediator.Send(new HomeClientPageQueryRequest());
            return Ok(response);
        }
    }
}
