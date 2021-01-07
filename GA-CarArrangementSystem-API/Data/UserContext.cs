using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using GA_CarArrangementSystem_API.DTO;

namespace GA_CarArrangementSystem_API.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
          : base(options)
        {
        }

        public virtual DbSet<UserAcc> UserAcc { get; set; }
        public virtual DbSet<GARole> GARole { get; set; }
        public virtual DbSet<GARoleUser> GARoleUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserAcc>().HasKey(x => x.id);
            modelBuilder.Entity<GARole>().HasKey(x => x.RoleId);
            modelBuilder.Entity<GARoleUser>().HasKey(x => x.Id);


        }
    }
}
