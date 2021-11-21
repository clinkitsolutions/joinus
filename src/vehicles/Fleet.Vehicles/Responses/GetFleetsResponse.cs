using Fleet.Vehicles.ViewModels;
using System.Collections.Generic;

namespace Fleet.Vehicles.Responses
{
    public class GetFleetsResponse
    {
        public IEnumerable<FleetViewModel> Fleets { get; set; }
    }
}