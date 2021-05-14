using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.DAL.Entities
{
    public class city
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public country Country { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
