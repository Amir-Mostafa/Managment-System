using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.DAL.Entities;
using review_1.Models;
namespace review_1.BL.interfaces
{
    public interface IDepartmentRepo
    {
        IQueryable<DepartmentVM> Get();
        void Add(DepartmentVM d);
        DepartmentVM getById(int id);
        void edit(DepartmentVM dpt);
        void delete(DepartmentVM dpt);
    }
}
