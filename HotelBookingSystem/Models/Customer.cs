using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; } 

        public string CustName { get; set; }
        public string CustCity { get; set; }


        public ICollection<Booking> Booking { get; set; }











    }
}
