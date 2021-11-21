using Fleet.Vehicles.Requests;
using Fleet.Vehicles.Responses;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Services
{
    public interface IFleetService
    {
        Task<GetFleetsResponse> GetFleetsAsync(GetFleetsRequest request);
    }
}
