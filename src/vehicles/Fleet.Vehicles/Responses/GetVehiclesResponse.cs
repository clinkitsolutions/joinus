using Fleet.Vehicles.ViewModels;
using System.Collections.Generic;

namespace Fleet.Vehicles.Responses
{
    public class GetVehiclesResponse
    {
        public IEnumerable<VehicleViewModel> Vehicles { get; set; }
    }
}
