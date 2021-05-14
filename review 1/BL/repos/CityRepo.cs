using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.Models;
using review_1.DAL.database;
using review_1.BL.interfaces;
namespace review_1.BL.repos
{
    public class CityRepo:ICityRepo
    {

        private DBcontext db;
        public CityRepo(DBcontext db)
        {
            this.db = db;

        }
        public IQueryable<cityVM> Get()
        {
            var data = db.Cities.Select(n => new cityVM { Id = n.Id, CountryId=n.CountryId  , CityName=n.CityName});
            return data;
        }

        public cityVM getById(int id)
        {
            return db.Cities.Where(n => n.Id == id).Select(n => new cityVM { Id = n.Id, CountryId = n.CountryId, CityName = n.CityName }).FirstOrDefault();
        }
    }
}
