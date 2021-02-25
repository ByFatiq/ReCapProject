using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class ColorValidator : AbstractValidator<Color>
    
    {
        public ColorValidator()
        {

            RuleFor(o => o.ColorId).NotEmpty();

            RuleFor(o => o.ColorName).NotEmpty(); 
            RuleFor(o => o.ColorName).MinimumLength(2);


        }


    }
}
