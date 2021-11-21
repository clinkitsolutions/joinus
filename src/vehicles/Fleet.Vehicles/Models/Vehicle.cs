using Fleet.Common;
using System.Collections.Generic;

namespace Fleet.Vehicles.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VehicleType Type { get; set; }

        public virtual ICollection<VehicleLogItem>? Log { get; set; }
        public virtual ICollection<VehicleFleet>? VehicleFleets { get; set; }
    }
}
