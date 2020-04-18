using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Data.Repos
{
    public interface IGiftRepository
    {
        void CreateMultiple(List<Gift> giftList);
        void SaveChanges();
        List<Gift> GetAll();
    }
}
