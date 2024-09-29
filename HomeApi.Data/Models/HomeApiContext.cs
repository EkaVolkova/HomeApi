using HomeApi.Data.Models.Devices;
using HomeApi.Data.Models.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Models
{
    public class HomeApiContext : DbContext
    {
        /// <summary>
        /// Датасет для таблицы Devices
        /// </summary>
        public DbSet<Device> Devices { get; set; }

        /// <summary>
        /// Датасет для таблицы Rooms
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        public HomeApiContext(DbContextOptions<HomeApiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().ToTable("Devices");
            modelBuilder.Entity<Room>().ToTable("Rooms");
        }
    }
}
