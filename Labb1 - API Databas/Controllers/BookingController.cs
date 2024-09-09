using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models.Dto.BookingDto;
using Labb1___API_Databas.Repositories.BookingRepo;
using Microsoft.AspNetCore.Mvc;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;


        public BookingController(IBookingService bookingService)
        {

            _bookingService = bookingService;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllReservationsAsync();
            return Ok(bookings);
        }
        [HttpGet]
        [Route("booking/{bookingId}")]
        public async Task<IActionResult> GetBookingById(int bookingId)
        {
            var booking = await _bookingService.GetReservationByIdAsync(bookingId);
            return Ok(booking);
        }
        [HttpPost]
        [Route("addBooking")]
        public async Task<IActionResult> AddBooking(BookingAddDto bookingAdd)
        {
            await _bookingService.AddReservationAsync(bookingAdd);
            return Ok();
        }
        [HttpPut]
        [Route("updateBooking/{bookingId}")]
        public async Task<IActionResult> UpdateBooking(int bookingId, BookingUpdateDto bookingUpdate)
        {
            await _bookingService.UpdateReservationAsync(bookingUpdate);
            return Ok();
        }
        [HttpDelete]
        [Route("deleteBooking/{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            await _bookingService.DeleteReservationAsync(bookingId);
            return Ok();
        }
    }
}
