using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Testimonial;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Testimonal.GetEditTestimonal;

public class GetEditTestimonalQueryHandler:IRequestHandler<GetEditTestimonalQueryRequest,ResponseModel<GetEditTestimonalQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Testimonial.Testimonial> _testimonialRepository;

    public GetEditTestimonalQueryHandler(IGenericRepository<Domain.Entities.Testimonial.Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public async Task<ResponseModel<GetEditTestimonalQueryResponse>> Handle(GetEditTestimonalQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
        {
            return ResponseModel<GetEditTestimonalQueryResponse>.Fail("Id is required");
        }

        var result = await _testimonialRepository.GetWhere(x => x.Id == request.Id)
            .Include(x => x.Photo)
            .Select(x => new GetEditTestimonalQueryResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Designation = x.Designation,
                Company = x.Company,
                Comment = x.Comment,
                Photo = x.Photo.Path
            }).FirstOrDefaultAsync(cancellationToken);

        if (result == null)
        {
            return ResponseModel<GetEditTestimonalQueryResponse>.Fail("Testimonial not found");
        }

        return ResponseModel<GetEditTestimonalQueryResponse>.Success(result);
    }
}