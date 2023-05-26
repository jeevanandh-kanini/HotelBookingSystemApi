using Flight_Booking.Models;
using Flight_Booking.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flight_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _repository;

        public FlightController(IFlightRepository repository)
        {
            _repository = repository;
        }

        /*//** [Authorize]*/


        [HttpGet]
        
        public async Task<IEnumerable<Flight>> GetAllFlight()
        {
            return await _repository.GetAllFlight();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetByIdFlight(int id)
        {
            var category = await _repository.GetByIdFlight(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }


       /* [HttpGet]

        public async Task<ActionResult<string>> GetCountOfProduct(int id)
        {

            var count = await _repository.GetCountOfProduct(id);

            if (count == null)
            {
                return NotFound();
            }


            return count;




        }*/
        [HttpPost]
        public async Task<ActionResult<Flight>> AddFlight([FromBody] Flight flight)
        {
            await _repository.AddFlight(flight);
            return CreatedAtAction(nameof(GetByIdFlight), new { id = flight.FlightId }, flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return BadRequest();
            }
            await _repository.UpdateFlight(flight);
            return NoContent();
        }

        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteFlight(int id)
        {

            if (!User.Identity.IsAuthenticated|| !User.IsInRole("admin"))
            {
                return Unauthorized("You are Not authorized");
            }


            return Ok(_repository.DeleteFlight(id));

           /* await _repository.DeleteFlight(id);
            return NoContent();*/
        }



        


    }




}

