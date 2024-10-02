using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models.Dto.BookingDto;
using Labb1___API_Databas.Models.Dto.CustomerDto;
using Labb1___API_Databas.Repositories.CustomerRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerRepo;
        private readonly RestaurantContext _context;
        public CustomerController(ICustomerService customerRepo, RestaurantContext restaurantContext)
        {
            _context = restaurantContext;
            _customerRepo = customerRepo;
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerDto addCustomerDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _customerRepo.AddCustomerAsync(addCustomerDto, cancellationToken);

                // Om du inte har möjlighet att returnera ID eller annan resursdetalj, returnera bara 201 Created.
                return StatusCode(200, "Added customer"); // Eller använd en annan lämplig metod
            }
            catch (Exception)
            {
                // Logga felet för felsökning
                // Exempel: _logger.LogError(ex, "An error occurred while adding the booking.");
                return StatusCode(500, "An error occurred while adding the booking.");
            }
        }
        [HttpGet("GetByPhoneNumber")]
        public async Task<IActionResult> GetByPhoneNumber(string phoneNumber)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

    }
}
