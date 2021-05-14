using review_1.DAL.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.Models;
using review_1.BL.interfaces;
namespace review_1.BL.repos
{
    public class CountryRepo:ICountryRepo
    {
        private DBcontext db;
        public CountryRepo(DBcontext db)
        {
            this.db = db;
            
        }
        public IQueryable<countryVM> Get()
        {
            var data = db.Countries.Select(n => new countryVM { Id=n.Id,CountryName=n.CountryName});
            return data;
        }
       
        public countryVM getById(int id)
        {
            return db.Countries.Where(n => n.Id == id).Select(n => new countryVM { Id = n.Id, CountryName = n.CountryName }).FirstOrDefault();
        }
      
    }
}
