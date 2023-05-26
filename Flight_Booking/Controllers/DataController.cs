using Flight_Booking.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Flight_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IFlightRepository _repository;

        public DataController(IFlightRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{id}/flightAdminCount")]
        public async Task<ActionResult<string>> GetFlightAdminCountByFlightId(int id)
        {

            var count = await _repository.GetFlightAdminCountByFlightId(id);

            if (count == null)
            {
                return NotFound();
            }


            return count;




        }

        [HttpGet("{id}/passengerCount")]
        public async Task<ActionResult<string>> GetPassengerCountByFlightId(int id)
        {

            var count = await _repository.GetPassengerCountByFlightId(id);

            if (count == null)
            {
                return NotFound();
            }


            return count;




        }
    }
}
