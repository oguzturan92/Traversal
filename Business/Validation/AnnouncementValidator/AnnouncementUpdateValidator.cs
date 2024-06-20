using Dto.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace Business.Validation
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(i => i.AnnouncementTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.AnnouncementContent).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}