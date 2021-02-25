using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
   public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            // İŞ KURALLARINI yazıyoruz.

            RuleFor(b => b.BrandId).NotEmpty(); //"b=>" Gelen brand değeri, Brandimizin ismi için boş geçilemez.
            

            RuleFor(b => b.BrandName).NotEmpty(); 
            RuleFor(b => b.BrandName).MinimumLength(2);
       
           
        }
    }

   


}
