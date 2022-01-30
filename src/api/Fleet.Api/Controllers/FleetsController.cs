using Fleet.Vehicles.Requests;
using Fleet.Vehicles.Responses;
using Fleet.Vehicles.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Api.Controllers
{
    [ApiController]
    [Route("api/fleets")]
    public class FleetsController : Controller
    {
        private readonly IFleetService _fleetService;

        public FleetsController(IFleetService fleetService)
        {
            _fleetService = fleetService;
        }

        /// <summary>
        /// Gets a list of fleets
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A list of fleets</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetFleetsAsync([FromQuery] GetFleetsRequest request)
        {
            GetFleetsResponse response;
            try
            {
                response = await _fleetService.GetFleetsAsync(request);
            }
            catch (Exception e)
            {
                // Log exception
                return StatusCode(500);
            }

            return Ok(response);
        }
    }
}
