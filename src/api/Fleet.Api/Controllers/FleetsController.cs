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
        public Task<GetFleetsResponse> GetFleetsAsync([FromQuery] GetFleetsRequest request) => _fleetService.GetFleetsAsync(request);
    }
}
