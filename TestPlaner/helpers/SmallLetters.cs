using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPlaner.helpers
{
    public class SmallLetters : ValidationAttribute
    {
        public string GetErrorMessage() =>
       $"must contain small letters";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {

            var password = (string)value;
            Regex rx = new Regex(@"^.*[a-z].*$",
          RegexOptions.Compiled);

            if (!rx.IsMatch(password))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
   
}
