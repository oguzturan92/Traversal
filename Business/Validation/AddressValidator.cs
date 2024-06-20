using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            
        }
    }
}