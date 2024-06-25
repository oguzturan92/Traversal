using Dto.DTOs.MessageDTOs;
using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class MessageValidator : AbstractValidator<MessageCreateDTO>
    {
        public MessageValidator()
        {
            RuleFor(i => i.MessageFullname).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.MessageMail).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.MessageSubject).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(i => i.MessageContent).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}