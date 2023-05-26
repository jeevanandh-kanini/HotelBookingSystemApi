using HotelBookingSystem.DTO;
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HotelBookingSystem.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddHotel(HotelDto hoteldto)
        {

            var hotel = new Hotel()
            {
                HotelName = hoteldto.HotelName,

                HotelLocation = hoteldto.HotelLocation,

                AvailableRooms = "0"


            };

        




            _context.Hotel.Add(hotel);

            await _context.SaveChangesAsync();
        }

        public async Task AddRoom(RoomDto roomdto)
        {


            var room = new Room();
            var hotel1 = await _context.Hotel.FindAsync(roomdto.HotelId);
            if (hotel1 != null)
            {
                room = new Room()
                {
                    RoomNumber = roomdto.RoomNumber,

                    RoomType = roomdto.RoomType,

                    RoomAvailability = roomdto.RoomAvailability,

                    RoomBedCount = roomdto.RoomBedCount,

                    HotelId = roomdto.HotelId


                };
            }
            else
            {
                throw new Exception("Hotel not found.");
            }

            var hotel = await _context.Hotel.FindAsync(room.HotelId);
            if (hotel != null)
            {
                int availableroom = Int32.Parse(hotel.AvailableRooms);
                // Check if there are available seats
                if (availableroom >= 0)
                {
                    // Reduce the available seats by 1
                    availableroom++;

                    hotel.AvailableRooms=availableroom.ToString();

                    // Add the passenger to the flight
                    _context.Room.Add(room);            

                    // Save the changes
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where there are no available seats
                    throw new Exception("Hotel Under Maintenance");
                }
            }
            else
            {
                // Handle the case where the flight doesn't exist
                throw new Exception("Hotel not found.");
            }





/*
            var room = new Room()
            {
                RoomNumber = roomdto.RoomNumber,

                RoomType = roomdto.RoomType,

                RoomAvailability = roomdto.RoomAvailability,    

                RoomBedCount = roomdto.RoomBedCount,    

                HotelId = roomdto.HotelId  


            };
            _context.Room.Add(room);
            await _context.SaveChangesAsync();*/

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

            var hotel = await _context.Hotel.FindAsync(room.HotelId);
            if (hotel != null)
            {
                int availableroom = Int32.Parse(hotel.AvailableRooms);
                // Check if there are available seats
                if (availableroom > 0)
                {
                    // Reduce the available seats by 1
                    availableroom--;

                    hotel.AvailableRooms = availableroom.ToString();

                    // Add the passenger to the flight

                    _context.Room.Remove(room);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    // Handle the case where there are no available seats
                    throw new Exception("Hotel Not Found");
                }
            }

   
            
        }

        public async Task<IEnumerable<Hotel>> GetAllHotel()
        {
            return await _context.Hotel.Include(a => a.Room).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            /*return await _context.Room.Include(a => a.Hotel).ToListAsync();*/

            return await _context.Room.ToListAsync();
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







        






        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetByIdCustomer(int id)
        {
            return await _context.Customer.Include(c => c.Booking).FirstOrDefaultAsync(c => c.CustId == id);
        }


        public async  Task AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }



        public async  Task UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await GetByIdCustomer(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
        }








        public async Task<IEnumerable<Booking>> GetAllBooking()
        {
            return await _context.Booking.ToListAsync();
        }

        public async Task<Booking> GetByIdBooking(int id)
        {
            return await _context.Booking.Include(c => c.Customer).Include(c => c.Room).FirstOrDefaultAsync(c => c.BookingId == id);
        }


        public async Task AddBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();
        }



       

        public async Task DeleteBooking(int id)
        {
            var booking = await GetByIdBooking(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
        }


















        public async Task<ActionResult<string>> GetRoomCountByHotelId(int hotelId)
        {
            /* return  _context.Passenger.CountAsync(p => p.FlightId == flightId).ToString();*/

            return _context.Room.Where(c => c.HotelId == hotelId).Count().ToString();
        }

        /*private readonly IEnumerable<Hotel> _hotels;*/


        public IEnumerable<Hotel> GetHotelsByLocation(string location)
        {
            // Retrieve hotels that match the provided location
            return _context.Hotel.Where(h => h.HotelLocation == location).ToList();

        }



        public IEnumerable<Room> GetRoomByRoomType(string roomtype)
        {
            // Retrieve hotels that match the provided location
            return _context.Room.Where(h => h.RoomType == roomtype).Include(r => r.Hotel).ToList();

        }
    }
}
