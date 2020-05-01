using Farm.Tracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Models.Db
{
    public class FarmContext : DbContext
    {
        public FarmContext(DbContextOptions<FarmContext> options) : base(options)
        {

        }

        public DbSet<Animals> Animals { get; set; }
        public DbSet<Buyers> Buyers { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Relocations> Relocations { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<Vaccinations> Vaccinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animals>().ToTable("Animals");
            modelBuilder.Entity<Buyers>().ToTable("Buyers");
            modelBuilder.Entity<Locations>().ToTable("Locations");
            modelBuilder.Entity<Purchases>().ToTable("Purchases");
            modelBuilder.Entity<Relocations>().ToTable("Relocations");
            modelBuilder.Entity<Sales>().ToTable("Sales");
            modelBuilder.Entity<Sellers>().ToTable("Sellers");
            modelBuilder.Entity<Vaccinations>().ToTable("Vaccinations");
        }
    }
}
