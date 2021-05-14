using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.Models
{
    public class RegistrationVM
    {
        [Required(ErrorMessage ="email required")]
        [EmailAddress(ErrorMessage ="Enter valid mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="min length 3")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "min length 3")]
        [Compare("Password",ErrorMessage ="Not Match")]
        [Display(Name ="Conform Password")]
        public string Conform { get; set; }

    }
}
