using AcconAPI.Application.Features.Commands.Service;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface IUpdateServiceContentCommandRequestValidator : IValidator<UpdateServiceCommandRequest> { }