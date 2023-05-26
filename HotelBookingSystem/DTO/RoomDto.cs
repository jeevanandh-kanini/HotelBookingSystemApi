using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTO
{
    public class RoomDto
    {

      
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string RoomAvailability { get; set; }
        public string RoomBedCount { get; set; }
        public int HotelId { get; set; }
        


    }
}
