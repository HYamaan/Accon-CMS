using AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUs;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface ICreateWhyChooseUsCommandRequestValidator : IValidator<UpdateWhyChooseUsCommandRequest> { }