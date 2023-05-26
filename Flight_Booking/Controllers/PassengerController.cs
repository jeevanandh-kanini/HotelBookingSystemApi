using Flight_Booking.DTO;
using Flight_Booking.Models;
using Flight_Booking.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {


        private readonly IFlightRepository _repository;

        public PassengerController(IFlightRepository repository)
        {
            _repository = repository;
        }

        /*    [Authorize]
    */
        [HttpGet]
        public async Task<IEnumerable<Passenger>> GetAllPassenger()
        {
            return await _repository.GetAllPassenger();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetByIdPassenger(int id)
        {
            var product = await _repository.GetByIdPassenger(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Passenger>> Add([FromBody] PassengerDto product)
        {
            await _repository.AddPassenger(product);
            return CreatedAtAction(nameof(GetByIdPassenger), new { id = product.FlightId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassenger(int id, [FromBody] Passenger product)
        {
            if (id != product.FlightId)
            {
                return BadRequest();
            }
            await _repository.UpdatePassenger(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            await _repository.DeletePassenger(id);

            return NoContent();
        }
    }
}
