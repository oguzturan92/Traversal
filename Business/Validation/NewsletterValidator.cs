using Dto.DTOs.NewsletterDTOs;
using FluentValidation;

namespace Business.Validation
{
    public class NewsletterValidator : AbstractValidator<NewsletterCreateDTO>
    {
        public NewsletterValidator()
        {
            RuleFor(i => i.NewsletterMail).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}