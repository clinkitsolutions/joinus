using System.Collections.Generic;

namespace Fleet.Vehicles.Models
{
    public class Fleet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VehicleFleet> VehicleFleets { get; set; }
    }
}
