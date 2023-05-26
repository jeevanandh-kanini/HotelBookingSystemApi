namespace Flight_Booking.Models
{
    public class Flight
    {
        public int FlightId { get; set; }


        public string FlightName { get; set; }


        public string  Departure     { get; set; }

        public string Destination { get; set; }


        public int AvailableSeat { get; set; }

        public ICollection<Passenger> Passenger { get; set; }

        public ICollection<FlightAdmin> FlightAdmin { get; set; }









    }
}
