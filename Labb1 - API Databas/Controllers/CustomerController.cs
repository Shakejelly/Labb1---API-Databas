using Labb1___API_Databas.Models.Dto.BookingDto;
using Labb1___API_Databas.Models.Dto.CustomerDto;
using Labb1___API_Databas.Repositories.CustomerRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerRepo;
        public CustomerController(ICustomerService customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpPost]
        [Route("api/AddCustomer")]
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
            catch (Exception ex)
            {
                // Logga felet för felsökning
                // Exempel: _logger.LogError(ex, "An error occurred while adding the booking.");
                return StatusCode(500, "An error occurred while adding the booking.");
            }
        }
    }
}
