using Flight_Booking.DTO;
using Flight_Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flight_Booking.Repositories
{
    public class FlightRepository:IFlightRepository
    {
        private readonly FlightDbContext _context;

        public FlightRepository(FlightDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetAllFlight()
        {
            return await _context.Flight.Include(a => a.Passenger).Include(b => b.FlightAdmin).ToListAsync();
        }

        public async Task<Flight> GetByIdFlight(int id)
        {
            return await _context.Flight.Include(c => c.Passenger).Include(c => c.FlightAdmin).FirstOrDefaultAsync(c => c.FlightId == id);
        }


      /*  public async Task<ActionResult<string>> GetCountOfProduct(int id)
        {


            return _context.Product.Where(c => c.CategoryId == id).Count().ToString();




        }*/



        public async Task AddFlight(Flight flight)
        {
            _context.Flight.Add(flight);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateFlight(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlight(int id)
        {
            var flight = await GetByIdFlight(id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
        }



        //////////////    
        /// <summary>
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        /// 
        public async Task<IEnumerable<FlightAdmin>> GetAllFlightAdmin()
        {

            return await _context.FlightAdmin.Include(a => a.Flight).ToListAsync();

        }

        public async Task<FlightAdmin> GetByIdFlightAdmin(int id)
        {
            return await _context.FlightAdmin.Include(c => c.Flight).FirstOrDefaultAsync(c => c.FlightId == id);
        }

        public async Task AddFlightAdmin(FlightAdminDto flightadmindto)
        {

            var flightadmin = new FlightAdmin()
            {
                AdminName = flightadmindto.AdminName,

                FlightId = flightadmindto.FlightId


            };
            _context.FlightAdmin.Add(flightadmin);  
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFlightAdmin(FlightAdmin flightadmin)
        {
            _context.Entry(flightadmin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAdmin(int id)
        {
            var flightadmin = await GetoByIdFlightAdmin(id);
            _context.FlightAdmin.Remove(flightadmin);
            await _context.SaveChangesAsync();

        }

        public async Task<FlightAdmin> GetoByIdFlightAdmin(int id)
        {
            return await _context.FlightAdmin.FindAsync(id);
        }



        /// <summary>
        /// ///


        public async Task<IEnumerable<Passenger>> GetAllPassenger()
        {
            return await _context.Passenger.Include(a => a.Flight).ToListAsync();
        }

        public async Task<Passenger> GetByIdPassenger(int id)
        {
            return await _context.Passenger.Include(c => c.Flight).FirstOrDefaultAsync(c => c.FlightId == id);
        }

        public async Task AddPassenger(PassengerDto passengerdto)
        {
            var passenger = new Passenger();
            var flight1 = await _context.Flight.FindAsync(passengerdto.FlightId);
            if (flight1 != null)
            {
                 passenger = new Passenger()
                {
                    PassengerName = passengerdto.PassengerName,

                    FlightId = passengerdto.FlightId


                };
            }
            else
            {
                throw new Exception("Flight not found.");
            }

            var flight = await _context.Flight.FindAsync(passenger.FlightId);
            if (flight != null)
            {
                // Check if there are available seats
                if (flight.AvailableSeat > 0)
                {
                    // Reduce the available seats by 1
                    flight.AvailableSeat--;

                    // Add the passenger to the flight
                    _context.Passenger.Add(passenger);

                    // Save the changes
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where there are no available seats
                    throw new Exception("No available seats in the flight.");
                }
            }
            else
            {
                // Handle the case where the flight doesn't exist
                throw new Exception("Flight not found.");
            }


           /* _context.Passenger.Add(passenger);
            await _context.SaveChangesAsync();*/
        }

        public async Task UpdatePassenger(Passenger passenger)
        {
            _context.Entry(passenger).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Passenger> GetoByIdPassenger(int id)
        {
            return await _context.Passenger.FindAsync(id);
        }

        public async  Task DeletePassenger(int id)
        {
            var passenger = await GetoByIdPassenger(id);
            _context.Passenger.Remove(passenger);
            await _context.SaveChangesAsync();
        }



        public async Task<ActionResult<string>> GetPassengerCountByFlightId(int flightId)
        {
           /* return  _context.Passenger.CountAsync(p => p.FlightId == flightId).ToString();*/

            return _context.Passenger.Where(c => c.FlightId == flightId).Count().ToString();
        }

        public async Task<ActionResult<string>> GetFlightAdminCountByFlightId(int flightId)
        {
            /* return  _context.FlightAdmin.CountAsync(fa => fa.FlightId == flightId).ToString();*/

            return _context.FlightAdmin.Where(c => c.FlightId == flightId).Count().ToString();
        }

       
    }
}
