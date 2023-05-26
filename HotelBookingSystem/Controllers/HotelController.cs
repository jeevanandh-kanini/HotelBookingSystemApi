using HotelBookingSystem.DTO;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }

       


        [HttpGet]

        public async Task<IEnumerable<Hotel>> GetAllHotel()
        {
            return await _repository.GetAllHotel();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetByIdHotel(int id)
        {
            var hotel = await _repository.GetByIdHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return hotel;
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
        public async Task<ActionResult<Hotel>> AddHotel([FromBody] HotelDto hotel)
        {
            await _repository.AddHotel(hotel);

            
            /*return CreatedAtAction(nameof(GetByIdHotel), new { id = hotel.HotelId }, hotel);*/

            return Ok(hotel);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return BadRequest();
            }
            await _repository.UpdateHotel(hotel);
            return NoContent();
        }

        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteHotel(int id)
        {

            if (!User.Identity.IsAuthenticated || !User.IsInRole("admin"))
            {
                return Unauthorized("You are Not authorized");
            }
            await _repository.DeleteHotel(id);
            

            return Ok("Deleted Successfully");

            /* await _repository.DeleteFlight(id);
             return NoContent();*/
        }



    }
}
