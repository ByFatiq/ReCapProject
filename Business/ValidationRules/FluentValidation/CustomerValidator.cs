using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class CustomerValidator:AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(cs => cs.Id).NotEmpty();

            RuleFor(cs => cs.CompanyName).NotEmpty();
            RuleFor(cs => cs.CompanyName).MinimumLength(2);

            

      




        }

    }
}
