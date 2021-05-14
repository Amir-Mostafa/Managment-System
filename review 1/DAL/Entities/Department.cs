using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.DAL.Entities
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        [MaxLength(20,ErrorMessage ="max length 20")]
        public string DepartmentName { get; set; }
        [MaxLength(20, ErrorMessage = "max length 20")]
        public string DepartmentCode { get; set; }

        public virtual ICollection<Employee>Employees { get; set; }


    }
}
