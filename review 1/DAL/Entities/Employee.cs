using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.DAL.Entities
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [MaxLength(20, ErrorMessage = "max length 20")]
        public string Name { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public float salary { get; set; }
        public DateTime Hiredate { get; set; }
        [Required(ErrorMessage ="enter address")]
        public string Address { get; set; }
        public int DepartmentID { get; set; }
        public string PhotoName { get; set; }
        public string CVName { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }


        
        public int cityId { get; set; }
        [ForeignKey("cityId")]
        public virtual city City { get; set; }

    }
}
