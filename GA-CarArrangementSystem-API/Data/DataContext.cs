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
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ArrangementInfo> ArrangementInfo { get; set; }
        public DbSet<CarInfo> CarInfo { get; set; }
        public DbSet<DriverInfo> DriverInfo { get; set; }
        public DbSet<RouteInfo> RouteInfo { get; set; }

        public DbSet<RouteSchedule> RouteSchedule { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArrangementInfo>().HasKey(x => x.ArrangementId);
            modelBuilder.Entity<ArrangementInfoDTO>(entity =>
            {
                entity.HasNoKey();
            });
            
        }
    }
}
