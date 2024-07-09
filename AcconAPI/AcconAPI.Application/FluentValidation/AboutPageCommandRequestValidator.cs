using AcconAPI.Application.Features.Commands.Pages.AboutPage;
using FluentValidation;
using Microsoft.AspNetCore.Http;

public class AboutPageCommandRequestValidator : AbstractValidator<AboutPageCommandRequest>
{
    public AboutPageCommandRequestValidator()
    {
        RuleFor(x => x.AboutHeader).NotEmpty().WithMessage("AboutHeader is required.");
        RuleFor(x => x.AboutContent).NotEmpty().WithMessage("AboutContent is required.");
        RuleFor(x => x.MissionHeader).NotEmpty().WithMessage("MissionHeader is required.");
        RuleFor(x => x.MissionContent).NotEmpty().WithMessage("MissionContent is required.");
        RuleFor(x => x.VisionHeader).NotEmpty().WithMessage("VisionHeader is required.");
        RuleFor(x => x.VisionContent).NotEmpty().WithMessage("VisionContent is required.");
        RuleFor(x => x.MetaTitle).NotEmpty().WithMessage("MetaTitle is required.");
        RuleFor(x => x.MetaDescription).NotEmpty().WithMessage("MetaDescription is required.");
        RuleFor(x => x.MetaKeywords).NotEmpty().WithMessage("MetaKeywords is required.");
    }
}