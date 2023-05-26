using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Models
{
    public class Booking
    {
        [Key]
         public int BookingId { get; set; }

        public int CustId { get; set; } 
        

        public int RoomId { get; set; }

        public Room? Room { get; set; }

        public Customer? Customer { get; set; }

    }
}
