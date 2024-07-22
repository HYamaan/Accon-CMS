using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.TestimonialPage;

public class TestimonialPageQueryHandler:IRequestHandler<TestimonialPageQueryRequest,ResponseModel<TestimonialPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.TestimonialPage> _testimonialPageRepository;

    public TestimonialPageQueryHandler(IGenericRepository<Domain.Entities.Page.TestimonialPage> testimonialPageRepository)
    {
        _testimonialPageRepository = testimonialPageRepository;
    }

    public async Task<ResponseModel<TestimonialPageQueryResponse>> Handle(TestimonialPageQueryRequest request, CancellationToken cancellationToken)
    {
       var testimonialPage = await _testimonialPageRepository.GetAll().FirstOrDefaultAsync();
       if (testimonialPage == null)
       {
           return ResponseModel<TestimonialPageQueryResponse>.Fail("Testimonial Page not found");
       }
       var response = new TestimonialPageQueryResponse
       {
           Title = testimonialPage.Heading,
           MetaTitle = testimonialPage.MetaTitle,
           MetaDescription = testimonialPage.MetaDescription,
           MetaKeywords = testimonialPage.MetaKeywords,
       };
       return ResponseModel<TestimonialPageQueryResponse>.Success(response);
    }
}