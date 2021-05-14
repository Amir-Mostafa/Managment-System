using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.DAL.Entities;
using review_1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace review_1.DAL.database
{
    public class DBcontext:IdentityDbContext
    {
     
        public DBcontext(DbContextOptions<DBcontext>dpt):base(dpt) 
        { }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<city> Cities { get; set; }
        public DbSet<country> Countries { get; set; }
        //public DbSet<review_1.Models.EmployeeVM> EmployeeVM { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=sharp;Trusted_Connection=True;");
        //}
    }
}
