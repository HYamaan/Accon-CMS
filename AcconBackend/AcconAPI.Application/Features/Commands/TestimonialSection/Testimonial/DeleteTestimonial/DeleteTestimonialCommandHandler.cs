using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.DeleteTestimonial;

public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommandRequest, ResponseModel<DeleteTestimonialCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Testimonial.Testimonial> _testimonialRepository;

    public DeleteTestimonialCommandHandler(IGenericRepository<Domain.Entities.Testimonial.Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public async Task<ResponseModel<DeleteTestimonialCommandResponse>> Handle(DeleteTestimonialCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
        {
            return ResponseModel<DeleteTestimonialCommandResponse>.Fail("Id is required");
        }

        try
        {
            await _testimonialRepository.RemoveAsync(request.Id.ToString());
            await _testimonialRepository.SaveAsync();
            return ResponseModel<DeleteTestimonialCommandResponse>.Success("Testimonial deleted successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<DeleteTestimonialCommandResponse>.Fail(e.Message);
        }
    }
}