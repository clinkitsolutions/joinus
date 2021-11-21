using Fleet.Common;
using System;

namespace Fleet.Vehicles.Models
{
    public class VehicleLogItem
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Location Location { get; set; }
    }
}
