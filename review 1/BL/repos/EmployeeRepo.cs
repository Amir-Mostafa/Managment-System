using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using review_1.BL.interfaces;
using review_1.DAL.database;
using review_1.Models;
using review_1.DAL.Entities;
using AutoMapper;
namespace review_1.BL.repos
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private DBcontext db;
        private readonly IMapper mapper;
        public EmployeeRepo(DBcontext db, IMapper _Mapper)
        {
            this.db = db;
            this.mapper = _Mapper;
        }
        public IQueryable<EmployeeVM> Get()
        {

            List <Employee>all = db.Employees.ToList();
            var data = db.Employees.Select(n => new EmployeeVM {DepartmentID=n.DepartmentID, Address=n.Address,age=n.age,DepartmentName=n.Department.DepartmentName,Hiredate=n.Hiredate,id=n.id,Name=n.Name,salary=n.salary,cityId =n.City.CityName, CVName = n.CVName, PhotoName = n.PhotoName });
            return data;
        }
        public void Add(EmployeeVM d)
        {


            var data = mapper.Map<Employee>(d);
            db.Employees.Add(data);
            db.SaveChanges();

        }
        public EmployeeVM getById(int id)
        {
            return db.Employees.Where(n => n.id == id).Select(n => new EmployeeVM {DepartmentID=n.DepartmentID, Address = n.Address, age = n.age, DepartmentName = n.Department.DepartmentName, Hiredate = n.Hiredate, id = n.id, Name = n.Name, salary = n.salary,cityId=n.City.CityName,CVName=n.CVName,PhotoName=n.PhotoName }).FirstOrDefault();
        }
        public void edit(EmployeeVM emp)
        {
            //Department d = db.Departments.Where(n => n.id == dpt.id).FirstOrDefault();
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void delete(EmployeeVM emp)
        {
            Employee d = db.Employees.Where(n => n.id == emp.id).FirstOrDefault();
            db.Employees.Remove(d);
            db.SaveChanges();
        }
        public DepartmentVM getDepartId(string name)
        {
           DepartmentVM d= db.Departments.Where(n => n.DepartmentName == name).Select(n => new DepartmentVM { id = n.id,DepartmentCode=n.DepartmentCode,DepartmentName=n.DepartmentName }).FirstOrDefault();

            return d;
        }
    }
}
