using Dto.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace Business.Validation
{
    public class AnnouncementCreateValidator : AbstractValidator<AnnouncementCreateDTO>
    {
        public AnnouncementCreateValidator()
        {
            RuleFor(i => i.AnnouncementTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.AnnouncementContent).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}