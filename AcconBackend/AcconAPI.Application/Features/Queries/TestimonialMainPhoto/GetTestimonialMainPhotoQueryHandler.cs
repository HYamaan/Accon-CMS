using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.TestimonialMainPhoto;

public class GetTestimonialMainPhotoQueryHandler:IRequestHandler<GetTestimonialMainPhotoQueryRequest,ResponseModel<GetTestimonialMainPhotoQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Testimonial.TestimonialMainPhoto> _testimonialMainPhotoRepository;

    public GetTestimonialMainPhotoQueryHandler(IGenericRepository<Domain.Entities.File.Testimonial.TestimonialMainPhoto> testimonialMainPhotoRepository)
    {
        _testimonialMainPhotoRepository = testimonialMainPhotoRepository;
    }

    public async Task<ResponseModel<GetTestimonialMainPhotoQueryResponse>> Handle(GetTestimonialMainPhotoQueryRequest request, CancellationToken cancellationToken)
    {
        
        try
        {
            var testimonialMainPhoto = await _testimonialMainPhotoRepository.GetAll().FirstOrDefaultAsync();
            if (testimonialMainPhoto == null)
            {
                return ResponseModel<GetTestimonialMainPhotoQueryResponse>.Fail("Testimonial Main Photo not found");
            }

            var result = new GetTestimonialMainPhotoQueryResponse()
            {
                Photo = testimonialMainPhoto.Path,
            };

            return ResponseModel<GetTestimonialMainPhotoQueryResponse>.Success(result);
        }
        catch (Exception e)
        {
            return ResponseModel<GetTestimonialMainPhotoQueryResponse>.Fail(e.Message);
        }
    }
}