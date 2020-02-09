using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestPlaner.helpers;

namespace TestPlaner.Dtos
{
    public class UserForRegsiterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
       
        [RegularExpression(@"^.*(?=.*\d).*$", ErrorMessage= "you must enter two numbers")]
        [SpecialChars()]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "must contains 6 characters")]
        [BigLetters()]
        [SmallLetters()]
        public string Password { get; set; }
    }
}
