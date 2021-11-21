using Fleet.Common;
using Fleet.Vehicles.Models;

namespace Fleet.Vehicles.ViewModels
{
    public class VehicleUpdateViewModel
    {
        public int? VehicleId { get; set; }
        public string? Name { get; set; }
        public VehicleType? Type { get; set; }
        public Location Location { get; set; }
    }
}
