using HotelBookingSystem.DTO;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repositories
{
    public interface IHotelRepository
    {

        Task<IEnumerable<Hotel>> GetAllHotel();
        Task<Hotel> GetByIdHotel(int id);

        Task AddHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int id);




        Task<IEnumerable<Room>> GetAllRoom();
        Task<Room> GetByIdRoom(int id);
        Task AddRoom(RoomDto room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);




    }
}
