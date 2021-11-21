using Fleet.Vehicles.Requests;
using Fleet.Vehicles.Responses;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Services
{
    public interface IVehicleService
    {
        Task<GetVehiclesResponse> GetVehiclesAsync(GetVehiclesRequest request);

        Task<UpdateVehicleLogsResponse> UpdateVehicleLogsAsync(UpdateVehicleLogsRequest request);
    }
}