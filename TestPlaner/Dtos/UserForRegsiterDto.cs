using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestPlaner.Dtos
{
    public class UserForRegsiterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8,MinimumLength = 6,ErrorMessage ="you must enter valid password")]
        public string Password { get; set; }
    }
}
