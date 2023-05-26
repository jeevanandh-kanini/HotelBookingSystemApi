using System.ComponentModel.DataAnnotations;

namespace Flight_Booking.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        public string PassengerName { get; set; }   



        public int FlightId { get;set; }    
        

        public  Flight? Flight { get; set; }



         
    }
}
