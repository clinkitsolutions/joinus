using Fleet.Vehicles.Requests;
using Fleet.Vehicles.Responses;
using Fleet.Vehicles.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Get a list of vehicles optionally filtered by fleet ID
        /// </summary>
        /// <param name="request">The optional fleet ID</param>
        /// <returns>A list of vehicles</returns>
        [Route("")]
        [HttpGet]
        public Task<GetVehiclesResponse> GetVehiclesAsync([FromQuery] GetVehiclesRequest request) => _vehicleService.GetVehiclesAsync(request);

        /// <summary>
        /// Update vehicle location logs
        /// </summary>
        /// <param name="request"></param>
        /// <returns>An empty response</returns>
        [Route("logs")]
        [HttpPost]
        public Task<UpdateVehicleLogsResponse> UpdateVehiclesAsync([FromBody] UpdateVehicleLogsRequest request) => _vehicleService.UpdateVehicleLogsAsync(request);
    }
}
