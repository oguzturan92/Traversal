using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            
        }
    }
}