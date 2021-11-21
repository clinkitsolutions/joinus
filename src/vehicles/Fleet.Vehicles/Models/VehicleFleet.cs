using System;

namespace Fleet.Vehicles.Models
{
    public class VehicleFleet
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int FleetId { get; set; }
        public Fleet Fleet { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
