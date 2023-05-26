using HotelBookingSystem.DTO;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {


        private readonly IHotelRepository _repository;

        public RoomController(IHotelRepository repository)
        {
            _repository = repository;
        }

        /*    [Authorize]
    */
        [HttpGet]
        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            return await _repository.GetAllRoom();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetByIdRoom(int id)
        {
            var room = await _repository.GetByIdRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> Add([FromBody] RoomDto room)
        {
            await _repository.AddRoom(room);
            return CreatedAtAction(nameof(GetByIdRoom), new { id = room.HotelId }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
        {
            if (id != room.RoomId)
            {
                return BadRequest();
            }
            await _repository.UpdateRoom(room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _repository.DeleteRoom(id);

            return NoContent();
        }
    }
}
