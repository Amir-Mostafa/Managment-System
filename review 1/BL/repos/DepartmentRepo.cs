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
    public class DepartmentRepo:IDepartmentRepo
    {
        private DBcontext db;
        private readonly IMapper mapper;
        public DepartmentRepo(DBcontext db,IMapper _Mapper)
        {
            this.db = db;
            this.mapper = _Mapper;
        }
        public IQueryable<DepartmentVM> Get()
        {
            var data = db.Departments.Select(n => new DepartmentVM { DepartmentName= n.DepartmentName,DepartmentCode= n.DepartmentCode,id= n.id });
            return data;
        }
        public void Add(DepartmentVM d)
        {

            
            var data = mapper.Map<Department>(d);
            db.Departments.Add(data);
            db.SaveChanges();
            
        }
        public DepartmentVM getById(int id)
        {
            return db.Departments.Where(n=>n.id==id).Select(n => new DepartmentVM { DepartmentName = n.DepartmentName, DepartmentCode = n.DepartmentCode, id = n.id }).FirstOrDefault();
        }
       public void edit(DepartmentVM dpt)
        {
            //Department d = db.Departments.Where(n => n.id == dpt.id).FirstOrDefault();
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void delete(DepartmentVM dpt)
        {
            Department d = db.Departments.Where(n => n.id ==dpt.id).FirstOrDefault();
            db.Departments.Remove(d);
            db.SaveChanges();
        }
    }
}
