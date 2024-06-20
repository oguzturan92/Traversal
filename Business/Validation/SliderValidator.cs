using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class SliderValidator : AbstractValidator<Slider>
    {
        public SliderValidator()
        {
            RuleFor(i => i.SliderTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.SliderSubTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.SliderImage).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}