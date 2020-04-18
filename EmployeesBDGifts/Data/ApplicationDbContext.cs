using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesBDGifts.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeesBDGifts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserVote> UserVotes { get; set; }
    }
}
