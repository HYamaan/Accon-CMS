using AcconAPI.Application.Features.Commands.ContactPage.ContactPageMail;
using FluentValidation;

public class ContactPageMailCommandRequestValidator : AbstractValidator<ContactPageMailCommandRequest>
{
    public ContactPageMailCommandRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim alanı boş olamaz")
            .MaximumLength(50).WithMessage("İsim 50 karakterden uzun olamaz");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta alanı boş olamaz")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefon alanı boş olamaz")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Geçerli bir telefon numarası girin");

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Mesaj alanı boş olamaz")
            .MaximumLength(500).WithMessage("Mesaj 500 karakterden uzun olamaz");
    }
}