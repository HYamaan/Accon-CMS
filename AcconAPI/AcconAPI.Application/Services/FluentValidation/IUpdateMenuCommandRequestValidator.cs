using AcconAPI.Application.Features.Commands.Menu;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface IUpdateMenuCommandRequestValidator : IValidator<UpdateMenuCommandRequest> { }