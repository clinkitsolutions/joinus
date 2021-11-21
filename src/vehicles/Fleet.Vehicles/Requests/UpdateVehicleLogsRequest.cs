using Fleet.Vehicles.ViewModels;

using System.Collections.Generic;

namespace Fleet.Vehicles.Requests
{
    public class UpdateVehicleLogsRequest
    {
        public IEnumerable<VehicleUpdateViewModel> Updates { get; set; }
    }
}