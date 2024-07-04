using AcconAPI.Application.Features.Commands.Language;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface ICreateLanguageCommandRequestValidator:IValidator<UpdateLanguageCommandRequest> { }
