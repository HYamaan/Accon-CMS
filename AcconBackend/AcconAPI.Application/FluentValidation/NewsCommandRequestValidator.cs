using AcconAPI.Application.Features.Commands.NewsSection.UpdateNews;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class NewsCommandRequestValidator
{
    public class CreateNewsCommandRequestValidator : AbstractValidator<UpdateNewsCommandRequest>, ICreateNewsCommandRequestValidator
    {
        public CreateNewsCommandRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.ShortContent)
                .NotEmpty().WithMessage("ShortContent is required.")
                .MaximumLength(200).WithMessage("ShortContent cannot be longer than 200 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot be longer than 500 characters.");

            RuleFor(x => x.PublishDate)
                .NotEmpty().WithMessage("PublishDate is required.");

            RuleFor(x => x.NewsCategoryId)
                .NotEmpty().WithMessage("NewsCategoryId is required.");

            RuleFor(x => x.CommentShow)
                .NotNull().WithMessage("CommentShow is required.");

            RuleFor(x => x.FeaturedPhoto)
                .NotNull().WithMessage("FeaturedPhoto is required.");

            RuleFor(x => x.BannerPhoto)
                .NotNull().WithMessage("BannerPhoto is required.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty().WithMessage("MetaTitle is required.")
                .MaximumLength(100).WithMessage("MetaTitle cannot be longer than 100 characters.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty().WithMessage("MetaDescription is required.")
                .MaximumLength(200).WithMessage("MetaDescription cannot be longer than 200 characters.");

            RuleFor(x => x.MetaKeyword)
                .NotEmpty().WithMessage("MetaKeyword is required.")
                .MaximumLength(100).WithMessage("MetaKeyword cannot be longer than 100 characters.");
        }
    }
    public class UpdateNewsCommandRequestValidator : AbstractValidator<UpdateNewsCommandRequest>, IUpdateNewsCommandRequestValidator
    {
        public UpdateNewsCommandRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.ShortContent)
                .NotEmpty().WithMessage("ShortContent is required.")
                .MaximumLength(200).WithMessage("ShortContent cannot be longer than 200 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot be longer than 500 characters.");

            RuleFor(x => x.PublishDate)
                .NotEmpty().WithMessage("PublishDate is required.");

            RuleFor(x => x.NewsCategoryId)
                .NotEmpty().WithMessage("NewsCategoryId is required.");

            RuleFor(x => x.CommentShow)
                .NotNull().WithMessage("CommentShow is required.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty().WithMessage("MetaTitle is required.")
                .MaximumLength(100).WithMessage("MetaTitle cannot be longer than 100 characters.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty().WithMessage("MetaDescription is required.")
                .MaximumLength(200).WithMessage("MetaDescription cannot be longer than 200 characters.");

            RuleFor(x => x.MetaKeyword)
                .NotEmpty().WithMessage("MetaKeyword is required.")
                .MaximumLength(100).WithMessage("MetaKeyword cannot be longer than 100 characters.");
        }
    }
}