using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.Models;
namespace review_1.BL.interfaces
{
    public interface ICityRepo
    {
        IQueryable<cityVM> Get();

        cityVM getById(int id);
    }
}
