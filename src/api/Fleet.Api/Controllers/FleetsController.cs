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
        private readonly ILogger _logger;

        /// <summary>
        /// Api Controller for Fleets 
        /// </summary>
        /// <param name="fleetService"></param>
        /// <param name="logger"></param>
        public FleetsController(
            IFleetService fleetService,
            ILogger<FleetsController> logger)
        {
            _fleetService = fleetService;
            _logger = logger;
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
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }

            return Ok(response);
        }
    }
}
