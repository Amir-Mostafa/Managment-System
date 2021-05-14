using Microsoft.AspNetCore.Http;
using review_1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.Models
{
    public class EmployeeVM
    {
        [Key]
        public int id { get; set; }
        [MaxLength(20, ErrorMessage = "max length 20")]
        [MinLength(3, ErrorMessage = "min length 3")]
        [Required]
        public string Name { get; set; }
        [Required]
        public int age { get; set; }

        [Required]
        [Range(100, 5000, ErrorMessage = "Should betwwen 100:5000")]
        public float salary { get; set; }
        public DateTime Hiredate { get; set; }
        [Required(ErrorMessage = "enter address")]
        [RegularExpression("[0-9]{2}-[a-zA-Z]{2,20}-[a-zA-Z]{2,20}-[a-zA-Z]{2,20}", ErrorMessage = "should be like 12-streetName-City-Coutry")]
        public string Address { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public string PhotoName { get; set; }
        public string CVName { get; set; }

        public IFormFile PhotoURL { get; set; }
        public IFormFile CVURL { get; set; }

        public string cityId { get; set; }

    }
}
