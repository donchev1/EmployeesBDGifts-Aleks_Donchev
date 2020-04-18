using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Data.Repos
{
    public class GiftRepository : IGiftRepository
    {
        public ApplicationDbContext _context;

        public GiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Gift> GetAll()
        {
            return _context.Gifts.ToList();
        }

        public void CreateMultiple(List<Gift> giftList)
        {
            _context.Gifts.AddRange(giftList);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
