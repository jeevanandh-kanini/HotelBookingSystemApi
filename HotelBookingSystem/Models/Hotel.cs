using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Models
{
    public class Hotel
    {
       
        public int HotelId { get; set; } 

        public string HotelName { get; set;}

        public string HotelLocation { get; set;} 


        public string AvailableRooms { get; set;}


        public int AvailableRoomsForBooking { get; set;}    


        public ICollection<Room> Room { get; set; }

    }

}
