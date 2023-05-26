using Flight_Booking.DTO;
using Flight_Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Booking.Repositories
{
    public interface IFlightRepository
    {

        Task<IEnumerable<Flight>> GetAllFlight();
        Task<Flight> GetByIdFlight(int id);




        /*Task<ActionResult<string>> GetCountOf(int id);*/

        Task AddFlight(Flight flight);
        Task UpdateFlight(Flight flight);
        Task DeleteFlight(int id);



        Task<ActionResult<string>> GetPassengerCountByFlightId(int flightId); 
        Task<ActionResult<string>> GetFlightAdminCountByFlightId(int flightId);





        Task<IEnumerable<FlightAdmin>> GetAllFlightAdmin();
        Task<FlightAdmin> GetByIdFlightAdmin(int id);
        Task AddFlightAdmin(FlightAdminDto flightadmin);
        Task UpdateFlightAdmin(FlightAdmin flightadmin);
        Task DeleteFlightAdmin(int id);



        Task<IEnumerable<Passenger>> GetAllPassenger();
        Task<Passenger> GetByIdPassenger(int id);
        Task AddPassenger(PassengerDto passenger);
        Task UpdatePassenger(Passenger passenger);
        Task DeletePassenger(int id);
    }
}
