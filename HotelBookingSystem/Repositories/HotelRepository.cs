using HotelBookingSystem.DTO;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);

            await _context.SaveChangesAsync();
        }

        public async Task AddRoom(RoomDto roomdto)
        {
            var room = new Room()
            {
                RoomNumber = roomdto.RoomNumber,

                RoomType = roomdto.RoomType,

                RoomAvailability = roomdto.RoomAvailability,    

                RoomBedCount = roomdto.RoomBedCount,    

                HotelId = roomdto.HotelId  


            };
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteHotel(int id)
        {
            var hotel = await GetByIdHotel(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await GetByIdRoom(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAllHotel()
        {
            return await _context.Hotel.Include(a => a.Room).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            return await _context.Room.Include(a => a.Hotel).ToListAsync();
        }




        public async Task<Hotel> GetByIdHotel(int id)
        {
            return await _context.Hotel.Include(c => c.Room).FirstOrDefaultAsync(c => c.HotelId == id);
        }

        public async Task<Room> GetByIdRoom(int id)
        {
            return await _context.Room.Include(c => c.Hotel).FirstOrDefaultAsync(c => c.RoomId == id);
        }





        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(Room room)
        {


           

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }



    }
}
