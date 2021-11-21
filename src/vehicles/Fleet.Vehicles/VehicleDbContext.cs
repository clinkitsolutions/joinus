using Fleet.Vehicles.Models;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Vehicles
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFleet> VehicleFleets { get; set; }
        public DbSet<Models.Fleet> Fleets { get; set; }
        public DbSet<VehicleLogItem> VehicleLogItems { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehicle>(vehicle =>
            {
                vehicle.Property(v => v.Id).ValueGeneratedOnAdd();
                vehicle.Property(v => v.Name).IsRequired(true);
                vehicle.Property(v => v.Type).HasConversion<string>();

                vehicle.HasData(new Vehicle
                {
                    Id = 1,
                    Name = "Truck#1",
                    Type = VehicleType.Truck
                });
            });

            builder.Entity<Models.Fleet>(fleet =>
            {
                fleet.Property(f => f.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<VehicleFleet>(vehicleFleet =>
            {
                vehicleFleet.HasKey(vf => new { vf.VehicleId, vf.FleetId });
                vehicleFleet.HasOne(vf => vf.Vehicle).WithMany(v => v.VehicleFleets).HasForeignKey(vf => vf.VehicleId);
                vehicleFleet.HasOne(vf => vf.Fleet).WithMany(f => f.VehicleFleets).HasForeignKey(vf => vf.FleetId);
            });

            builder.Entity<VehicleLogItem>(log =>
            {
                log.Property(l => l.Id).ValueGeneratedOnAdd();
                log.OwnsOne(l => l.Location);
            });
        }
    }
}
