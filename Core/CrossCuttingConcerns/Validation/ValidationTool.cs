using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator valitator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = valitator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
