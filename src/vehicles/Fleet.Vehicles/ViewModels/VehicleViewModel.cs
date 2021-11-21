using Fleet.Common;
using Fleet.Vehicles.Models;

namespace Fleet.Vehicles.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VehicleType Type { get; set; }
        public Location? LastKnownLocation { get; set; }
    }
}
