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
        public async Task<IActionResult> GetVehiclesAsync([FromQuery] GetVehiclesRequest request)
        {
            GetVehiclesResponse response;
            try
            {
                response = await _vehicleService.GetVehiclesAsync(request);
            }
            catch (Exception e)
            {
                //Log exception
                return StatusCode(500);
            }

            return Ok(response);
        }

        /// <summary>
        /// Update vehicle location logs
        /// </summary>
        /// <param name="request"></param>
        /// <returns>An empty response</returns>
        [Route("logs")]
        [HttpPost]
        public async Task<IActionResult> UpdateVehiclesAsync([FromBody] UpdateVehicleLogsRequest request)
        {
            UpdateVehicleLogsResponse response;
            try
            {
                response = await _vehicleService.UpdateVehicleLogsAsync(request);
            }
            catch (Exception e)
            {
                // Log exception
                return StatusCode(500);
            }

            return Ok(response);
        }

        /// <summary>
        /// Update vehicle location logs from CSV file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>An empty response</returns>
        [Route("logs/csv")]
        [HttpPut("UploadFiles")]
        public async Task<IActionResult> UpdateVehiclesFromCsvAsync(IFormFile file)
        {
            UpdateVehicleLogsResponse response;
            try
            {
                response = await _vehicleService.UpdateVehicleLogsFromCsvAsync(file);
            }
            catch (ArgumentException e)
            {
                // Log exception
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                // Log exception
                return StatusCode(500);
            }

            return Accepted(response);
        }
    }
}
