using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(i => i.AboutTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.AboutDescription).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.AboutImage).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.AboutTitle2).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.AboutDescription2).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}