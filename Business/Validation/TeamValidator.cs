using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            
        }
    }
}