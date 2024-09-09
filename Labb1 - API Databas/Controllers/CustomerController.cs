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
    }
}
