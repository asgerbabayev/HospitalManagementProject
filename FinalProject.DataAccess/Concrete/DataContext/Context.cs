using FinalProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.DataAccess.Concrete.DataContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=FinalDb;Username=postgres;Password=12345;Port=5433");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Registry> Registries { get; set; }
    }
}
