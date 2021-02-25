using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarDescription).NotEmpty();
            RuleFor(c => c.CarDescription).MinimumLength(2);

            RuleFor(c => c.BrandId).GreaterThan(0);

           
        }
    }
}
