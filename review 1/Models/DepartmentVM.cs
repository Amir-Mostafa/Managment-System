using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace review_1.Models
{
    public class DepartmentVM
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Enter Department Name")]
        [MaxLength(20, ErrorMessage = "max length 20")]
        [MinLength(3, ErrorMessage = "MIN length 3")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Enter Department Code")]
        [MaxLength(20, ErrorMessage = "max length 20")]
        [MinLength(1, ErrorMessage = "MIN length 1")]
        public string DepartmentCode { get; set; }
    }
}
