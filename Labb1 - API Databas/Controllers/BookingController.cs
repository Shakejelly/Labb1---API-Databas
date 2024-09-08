using Labb1___API_Databas.Data;
using Labb1___API_Databas.Repositories.BookingRepo;
using Microsoft.AspNetCore.Mvc;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepo _bookingRepo;


        public BookingController(IBookingRepo bookingRepo)
        {

            _bookingRepo = bookingRepo;
           
        }
    }
}
