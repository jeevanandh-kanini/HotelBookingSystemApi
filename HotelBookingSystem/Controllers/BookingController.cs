using HotelBookingSystem.DTO;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IHotelRepository _repository;

        public BookingController(IHotelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Booking>> GetAllBooking()
        {
            return await _repository.GetAllBooking();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetByIdBooking(int id)
        {
            var booking = await _repository.GetByIdBooking(id);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Add([FromBody] BookingDto booking)
        {
            await _repository.AddBooking(booking);
            return Ok(booking);
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _repository.DeleteBooking(id);
            return NoContent();
        }


    }
}
