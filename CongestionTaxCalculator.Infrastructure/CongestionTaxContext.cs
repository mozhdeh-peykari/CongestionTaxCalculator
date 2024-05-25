using CongestionTaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CongestionTaxCalculator.Infrastructure
{
    public class CongestionTaxContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TaxRule> TaxRules { get; set; }
        public DbSet<TaxExemption> TaxExemptions { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=CongestionTax;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Vehicle>()
                .HasOne(e => e.VehicleType).WithMany().HasForeignKey(e => e.VehicleTypeId);

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, Name = "Private car" },
                new VehicleType { Id = 2, Name = "Emergency vehicle" }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Model = "Porsche", Registration = "AB12CDE", VehicleTypeId = 1 }
            );

            modelBuilder.Entity<TaxRule>().HasData(
                new TaxRule { Id = 1, From = new TimeSpan(hours: 6, minutes: 0, seconds: 0), To = new TimeSpan(6, 29, 0), Amount = 8 }
            );

            modelBuilder.Entity<TaxExemption>().HasData(
                new TaxExemption { Id = 1, Type = TaxExemptionType.DayOfWeek, Value = 0 } //sunday
            );
        }
    }
}
