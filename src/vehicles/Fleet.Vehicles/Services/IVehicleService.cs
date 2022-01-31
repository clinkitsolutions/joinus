using Fleet.Vehicles.Requests;
using Fleet.Vehicles.Responses;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Services
{
    public interface IVehicleService
    {
        Task<GetVehiclesResponse> GetVehiclesAsync(GetVehiclesRequest request);

        Task<UpdateVehicleLogsResponse> UpdateVehicleLogsAsync(UpdateVehicleLogsRequest request);

        Task<UpdateVehicleLogsResponse> UpdateVehicleLogsFromCsvAsync(IFormFile request);
    }
}