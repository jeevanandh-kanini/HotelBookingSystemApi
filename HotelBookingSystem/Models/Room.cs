namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }  
        public string RoomNumber { get; set; }    
        public string RoomType { get; set; }
        public string RoomAvailability { get; set;}
        public string RoomBedCount { get; set;}
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }



    }
}
