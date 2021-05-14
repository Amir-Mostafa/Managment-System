using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.Models
{
    public class RoleVM
    {
        [Required]
        public string Name { get; set; }
        public string id { get; set; }
    }
}
