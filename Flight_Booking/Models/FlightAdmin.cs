using System.ComponentModel.DataAnnotations;

namespace Flight_Booking.Models
{
    public class FlightAdmin
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminName { get; set; }



        public int FlightId { get; set; }


        public Flight? Flight { get; set; }



    }
}
