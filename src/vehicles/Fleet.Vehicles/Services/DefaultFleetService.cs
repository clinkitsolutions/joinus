using Fleet.Vehicles.Repositories;
using Fleet.Vehicles.Requests;
using Fleet.Vehicles.Responses;
using Fleet.Vehicles.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Services
{
    public class DefaultFleetService : IFleetService
    {
        private readonly IFleetRepository _fleetRepository;

        public DefaultFleetService(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<GetFleetsResponse> GetFleetsAsync(GetFleetsRequest request)
        {
            var fleets = await _fleetRepository.GetAsync();
            var response = new GetFleetsResponse
            {
                Fleets = fleets.Select(f => new FleetViewModel
                {
                    Id = f.Id,
                    Name = f.Name
                })
            };

            return response;
        }
    }
}
