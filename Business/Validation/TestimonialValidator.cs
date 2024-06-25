using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(i => i.TestimonialFullname).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.TestimonialComment).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.TestimonialImage).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}