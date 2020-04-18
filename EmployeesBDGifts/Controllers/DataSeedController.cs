using EmployeesBDGifts.Data;
using EmployeesBDGifts.Data.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Controllers
{
    public class DataSeedController :Controller
    {
        public IUserRepository _userRepository;
        public IGiftRepository _giftRepository;


        public DataSeedController(IUserRepository userRepository, IGiftRepository giftRepository)
        {
            _userRepository = userRepository;
            _giftRepository = giftRepository;
        }

        public void SeedData()
        {
            DataSeeds.SeedUsers(_userRepository);
            DataSeeds.SeedGifts(_giftRepository);
        }

    }
}
