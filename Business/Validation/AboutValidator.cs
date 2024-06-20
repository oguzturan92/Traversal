using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(i => i.AboutTitle).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}