using AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.UpdateTestimonial;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface IUpdateTestimonialCommandRequestValidator : IValidator<UpdateTestimonialCommandRequest> { }