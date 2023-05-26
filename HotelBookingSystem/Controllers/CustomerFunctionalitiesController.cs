using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFunctionalitiesController : ControllerBase
    {
        private readonly IHotelRepository _repository;


        public CustomerFunctionalitiesController(IHotelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}/RoomCountWithHotelId")]
        public async Task<ActionResult<string>> GetRoomCountByHotelId(int id)
        {

            var count = await _repository.GetRoomCountByHotelId(id);

            if (count == null)
            {
                return NotFound();
            }


            return count;




        }





        /*[HttpGet("{id}/RoomByLocation")]
        public async Task<ActionResult<string>> GetRoomByLocation(string location)
        {

            var count = await _repository.GetRoomByLocation(string location);

            if (count == null)
            {
                return NotFound();
            }


            return count;




        }*/



        [HttpGet("{location}/HotelWithLocation")]
        public IActionResult GetHotelsByLocation(string location)
        {
            IEnumerable<Hotel> hotels = _repository.GetHotelsByLocation(location);

            if (hotels == null)
            {
                return NotFound(); // Return 404 Not Found if no hotels are found for the location
            }

            return Ok(hotels); // Return the list of hotels as a 200 OK response
        }



        [HttpGet("{roomtype}/RoomWithRoomType")]
        public IActionResult GetRoomByRoomType(string roomtype)
        {
            IEnumerable<Room> rooms = _repository.GetRoomByRoomType(roomtype);

            if (rooms == null)
            {
                return NotFound(); // Return 404 Not Found if no hotels are found for the location
            }

            return Ok(rooms); // Return the list of hotels as a 200 OK response
        }




    }
}
