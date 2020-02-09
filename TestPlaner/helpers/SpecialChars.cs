using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPlaner.helpers
{
    public class SpecialChars : ValidationAttribute
    {
        public string GetErrorMessage() =>
       $"must contain special characters";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
          
            var password = (string)value;
            Regex rx = new Regex(@"^.*(?=.*[!@#$%^&+=]).*$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
          
            if (!rx.IsMatch(password))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
