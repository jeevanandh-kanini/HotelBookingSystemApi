using Flight_Booking.DTO;
using Flight_Booking.Models;
using Flight_Booking.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightAdminController : ControllerBase
    {

        private readonly IFlightRepository _repository;

        public FlightAdminController(IFlightRepository repository)
        {
            _repository = repository;
        }

        /*    [Authorize]
    */
        [HttpGet]
        public async Task<IEnumerable<FlightAdmin>> GetAll()
        {
            return await _repository.GetAllFlightAdmin();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightAdmin>> GetByIdFlightAdmin(int id)
        {
            var product = await _repository.GetByIdFlightAdmin(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<FlightAdmin>> Add([FromBody] FlightAdminDto product)
        {
           /* var flightadmin = new FlightAdmin
            {

            }*/
            await _repository.AddFlightAdmin(product);
            return CreatedAtAction(nameof(GetByIdFlightAdmin), new { id = product.FlightId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlightAdmin(int id, [FromBody] FlightAdmin product)
        {
            if (id != product.FlightId)
            {
                return BadRequest();
            }
            await _repository.UpdateFlightAdmin(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightAdmin(int id)
        {
            await _repository.DeleteFlightAdmin(id);

            return NoContent();
        }




    }
}
