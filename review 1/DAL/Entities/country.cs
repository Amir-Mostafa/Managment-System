using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.DAL.Entities
{
    public class country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<city> Cities { get; set; }
    }
}
