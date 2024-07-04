using AcconAPI.Application.Features.Commands.SocialMedia;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class SocialMediaCommandRequestValidator
{
    public class UpdateSocialMediaCommandRequestValidator : AbstractValidator<UpdateSocialMediaCommandRequest>, IUpdateSocialMediaCommandRequestValidator
    {
        public UpdateSocialMediaCommandRequestValidator()
        {
            RuleForEach(x => x.Socials).ChildRules(social =>
            {
                social.RuleFor(x => x.Id).NotNull().WithMessage("Id is required for update.");
                social.RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required for update.");
            });
        }
    }

    public class CreateSocialMediaCommandRequestValidator : AbstractValidator<UpdateSocialMediaCommandRequest>, ICreateSocialMediaCommandRequestValidator
    {
        public CreateSocialMediaCommandRequestValidator()
        {
            RuleForEach(x => x.Socials).ChildRules(social =>
            {
                social.RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required for create.");
                social.RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required for create.");
            });
        }
    }
}