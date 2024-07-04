using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using AcconAPI.Domain.Entities.Testimonial;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Testimonal.GetAllTestimonal;

public class GetAllTestimonalQueryHandler : IRequestHandler<GetAllTestimonalQueryRequest, ResponseModel<GetAllTestimonalQueryResponse>>
{
    private readonly IGenericRepository<TestimonialPage> _testimonialPageRepository;

    public GetAllTestimonalQueryHandler(IGenericRepository<TestimonialPage> testimonialPageRepository)
    {
        _testimonialPageRepository = testimonialPageRepository;
    }

    public async Task<ResponseModel<GetAllTestimonalQueryResponse>> Handle(GetAllTestimonalQueryRequest request, CancellationToken cancellationToken)
    {
        var testimonials = await _testimonialPageRepository.GetAll()
            .Include(x => x.Testimonials)
            .ThenInclude(x => x.Photo)
            .Select(ux => new GetAllTestimonalQueryResponse()
            {
                MetaTitle = ux.MetaTitle,
                MetaDescription = ux.MetaDescription,
                MetaKeywords = ux.MetaKeywords,
                Testimonials = ux.Testimonials.Select(x => new GetAllTestimonialResponseDTOs()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Designation = x.Designation,
                    Company = x.Company,
                    Comment = x.Comment,
                    Photo = x.Photo.Path
                }).ToList()
            }).FirstOrDefaultAsync();

        if (testimonials == null)
        {
            return ResponseModel<GetAllTestimonalQueryResponse>.Fail("Testimonials not found");
        }


        return ResponseModel<GetAllTestimonalQueryResponse>.Success(testimonials);


    }
}