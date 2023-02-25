using Microsoft.EntityFrameworkCore;
using ParkingLot.Domain.Payment.Entities;
using ParkingLot.Domain.Stay.Entities;
using ParkingLot.Domain.Vehicle.Entities;

namespace ParkingLot.Infrastructure.Database
{
    public class ParkingLotDbContext : DbContext
    {
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<Stay>? Stays { get; set; }
        public DbSet<Payment>? Payments { get; set; }


        public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.HasKey(v => v.Plate);
            });

            modelBuilder.Entity<Stay>(stay =>
            {
                stay.HasKey(s => s.StayId);

                stay.Property(s => s.StayId).HasDefaultValueSql("NEWID()");

                stay.HasOne(s => s.Vehicle)
                    .WithMany(v => v.Stays)
                    .HasForeignKey(s => s.VehiclePlate);
            });

            modelBuilder.Entity<Payment>(payment =>
            {
                payment.HasKey(p => p.PaymentId);

                payment.Property(p => p.PaymentId).HasDefaultValueSql("NEWID()");

                payment.HasOne(p => p.Stay)
                       .WithOne(s => s.Payment)
                       .HasForeignKey<Payment>(s => s.StayId);
            });
        }
    }
}
