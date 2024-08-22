using Labb1___API_Databas.Data;
using Microsoft.AspNetCore.Mvc;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public BookingController(RestaurantContext context)
        {
            _context = context;
        }
        
    }
}
