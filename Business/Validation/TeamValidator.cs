using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(i => i.TeamFullname).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.TeamDescription).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.TeamImage).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}