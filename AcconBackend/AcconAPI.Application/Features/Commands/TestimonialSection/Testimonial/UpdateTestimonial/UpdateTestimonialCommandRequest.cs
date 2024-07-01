using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.UpdateTestimonial;

public class UpdateTestimonialCommandRequest : IRequest<ResponseModel<UpdateTestimonialCommandResponse>>
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Company { get; set; }
    public IFormFile Photo { get; set; }
    public string Comment { get; set; }
}