using HotelBookingSystem.DTO;
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Repositories
{
    public interface IHotelRepository
    {

        Task<IEnumerable<Hotel>> GetAllHotel();
        Task<Hotel> GetByIdHotel(int id);

        Task AddHotel(HotelDto hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int id);




        Task<IEnumerable<Room>> GetAllRoom();
        Task<Room> GetByIdRoom(int id);
        Task AddRoom(RoomDto room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);



        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetByIdCustomer(int id);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);




        Task<IEnumerable<Booking>> GetAllBooking();
        Task<Booking> GetByIdBooking(int id);
        Task AddBooking(Booking booking);
        Task DeleteBooking(int id);




















        Task<ActionResult<string>> GetRoomCountByHotelId(int hotelId);

       /* public IEnumerable<Hotel> GetHotelsByLocation(string location);*/
        IEnumerable<Hotel> GetHotelsByLocation(string location);

        IEnumerable<Room> GetRoomByRoomType(string roomtype);









    }
}
