using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IHotelRepository _repository;

        public CustomerController(IHotelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _repository.GetAllCustomer();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetByIdCustomer(int id)
        {
            var customer = await _repository.GetByIdCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Add([FromBody] Customer customer)
        {
            await _repository.AddCustomer(customer);
            return CreatedAtAction(nameof(GetByIdCustomer), new { id = customer.CustId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustId)
            {
                return BadRequest();
            }
            await _repository.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _repository.DeleteCustomer(id);
            return NoContent();
        }

    }
}
