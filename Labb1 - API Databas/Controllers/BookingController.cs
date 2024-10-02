using Labb1___API_Databas.Models.Dto.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Labb1___API_Databas.Repositories.BookingRepo;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        [Route("getAllBookings")]
        public async Task<IActionResult> GetAllBookings(CancellationToken cancellationToken)
        {
            try
            {
                var bookings = await _bookingService.GetAllReservationsAsync(cancellationToken);
                return Ok(bookings);
            }
            catch (Exception)
            {
                // Logga felet
                return StatusCode(500, "An error occurred while retrieving bookings.");
            }
        }
        [HttpGet]
        [Authorize]
        [Route("booking/{bookingId}")]
        public async Task<IActionResult> GetBookingById(int bookingId, CancellationToken cancellationToken)
        {
            try
            {
                var booking = await _bookingService.GetReservationByIdAsync(bookingId, cancellationToken);
                if (booking == null)
                {
                    return NotFound($"Booking with ID {bookingId} not found.");
                }
                return Ok(booking);
            }
            catch (Exception)
            {
                // Logga felet
                return StatusCode(500, "An error occurred while retrieving the booking.");
            }
        }
        [HttpPost]
        [Route("addBooking")]
        public async Task<IActionResult> AddBooking(BookingAddDto bookingAddDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bookingService.AddReservationAsync(bookingAddDto, cancellationToken);

                // Om du inte har möjlighet att returnera ID eller annan resursdetalj, returnera bara 201 Created.
                return CreatedAtAction(nameof(GetAllBookings), null); // Eller använd en annan lämplig metod
            }
            catch (Exception)
            {
                // Logga felet för felsökning
                // Exempel: _logger.LogError(ex, "An error occurred while adding the booking.");
                return StatusCode(500, "An error occurred while adding the booking.");
            }
        }
        [HttpPut]
        [Authorize]
        [Route("updateBooking/{bookingId}")]
        public async Task<IActionResult> UpdateBooking(int bookingId, BookingUpdateDto bookingUpdateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bookingUpdateDto.BookingId = bookingId; // Ensures the bookingId is set in the DTO
                await _bookingService.UpdateReservationAsync(bookingUpdateDto, cancellationToken);
                return NoContent(); // Indicate success without returning data
            }
            catch (Exception)
            {
                // Logga felet
                return StatusCode(500, "An error occurred while updating the booking.");
            }
        }
        [HttpDelete]
        [Authorize]
        [Route("deleteBooking/{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId, CancellationToken cancellationToken)
        {
            try
            {
                await _bookingService.DeleteReservationAsync(bookingId, cancellationToken);
                return NoContent(); // Indicate success without returning data
            }
            catch (Exception)
            {
                // Logga felet
                return StatusCode(500, "An error occurred while deleting the booking.");
            }
        }
    }
}
