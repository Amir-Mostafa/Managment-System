using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace review_1.Models
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "email required")]
        [EmailAddress(ErrorMessage = "Enter valid mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "min length 3")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "min length 3")]
        [Compare("Password", ErrorMessage = "Not Match")]
        [Display(Name = "Conform Password")]
        public string Conform { get; set; }

        public string Token { get; set; }
    }
}
