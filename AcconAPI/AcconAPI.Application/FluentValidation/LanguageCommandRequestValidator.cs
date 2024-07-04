using AcconAPI.Application.Features.Commands.Language;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class LanguageCommandRequestValidator
{
    public class UpdateLanguageCommandRequestValidator : AbstractValidator<UpdateLanguageCommandRequest>, IUpdateLanguageCommandRequestValidator
    {
        public UpdateLanguageCommandRequestValidator()
        {
            RuleForEach(x => x.languages).ChildRules(language =>
            {
                language.RuleFor(x => x.Id).NotNull().WithMessage("Id is required for update.");
                language.RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required for update.");
            });
        }
    }
    public class CreateLanguageCommandRequestValidator : AbstractValidator<UpdateLanguageCommandRequest>, ICreateLanguageCommandRequestValidator
    {
        public CreateLanguageCommandRequestValidator()
        {
            RuleForEach(x => x.languages).ChildRules(language =>
            {
                language.RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required for create.");
                language.RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required for create.");
            });
        }
    }
}