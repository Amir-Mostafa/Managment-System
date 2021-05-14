using review_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.BL.interfaces
{
   public interface IEmployeeRepo
    {
        IQueryable<EmployeeVM> Get();
        void Add(EmployeeVM d);
        EmployeeVM getById(int id);
        void edit(EmployeeVM emp);
        void delete(EmployeeVM emp);
        DepartmentVM getDepartId(string name);
    }
}
