using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.DeleteTestimonial;

public class DeleteTestimonialCommandRequest : IRequest<ResponseModel<DeleteTestimonialCommandResponse>>
{
    public Guid? Id { get; set; }
}