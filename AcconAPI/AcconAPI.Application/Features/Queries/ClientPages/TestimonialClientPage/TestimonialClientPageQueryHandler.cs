using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.TestimonialPage;

public class TestimonialClientPageQueryHandler:IRequestHandler<TestimonialClientPageQueryRequest,ResponseModel<TestimonialClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.TestimonialPage> _testimonialPageRepository;

    public TestimonialClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.TestimonialPage> testimonialPageRepository)
    {
        _testimonialPageRepository = testimonialPageRepository;
    }

    public async Task<ResponseModel<TestimonialClientPageQueryResponse>> Handle(TestimonialClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var testimonialPage = await _testimonialPageRepository.GetWhere(x => x.IsPublished)
                .Include(x => x.Testimonials)
                .ThenInclude(x => x.Photo)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (testimonialPage == null)
                return ResponseModel<TestimonialClientPageQueryResponse>.Fail("Testimonial page not found");

            var testimonials = testimonialPage.Testimonials
                .Select(x => new GetClientTestimonialPageResponseDTOs()
                {
                    Name = x.Name,
                    Position = x.Company,
                    Description = x.Comment,
                    Photo = x.Photo?.Path
                }).ToList();

            var response = new TestimonialClientPageQueryResponse()
            {
                Header = testimonialPage.Heading,
                MetaTitle = testimonialPage.MetaTitle,
                MetaDescription = testimonialPage.MetaDescription,
                MetaKeywords = testimonialPage.MetaKeywords,
                Testimonials = testimonials
            };
            return ResponseModel<TestimonialClientPageQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<TestimonialClientPageQueryResponse>.Fail(e.Message);
        }
    }
}