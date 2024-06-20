using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(i => i.BannerTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.BannerDescription).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.BannerImage).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}