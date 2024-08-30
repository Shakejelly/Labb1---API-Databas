using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models.Dto;
using Labb1___API_Databas.Repositories.BookingRepo;
using Microsoft.AspNetCore.Mvc;
using Labb1___API_Databas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using Labb1___API_Databas.Models.ViewModel;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private readonly IBookingRepo _bookingRepo;

        public BookingController(RestaurantContext context, IBookingRepo bookingRepo)
        {
            
            _bookingRepo = bookingRepo;
            _context = context;
        }

        // Book a reservation
        public async Task<IActionResult> AddReservation([FromBody]AddReservationDto addReservationDto)
        {
            try
            {
            var newReservation = new Booking
            {
                BookingDate = addReservationDto.BookingDate,
                TableAmount = addReservationDto.ReservationAmount,
                Customer = new Customer
                {
                    PhoneNumber = addReservationDto.
                }

            };
            var result = await _bookingRepo.AddCustomerToReservationAsync(newReservation);
            await _bookingRepo.MakeReservationAsync(newReservation);
            return Ok(result);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Deleting the reservation (Should be done by the admin)
        [HttpDelete("delete_reservation")]
        [Authorize]
        public async Task<IActionResult> DeleteReservation([FromBody] DeleteReservationDTO deleteReservationdto)
        {
            var booking = await _bookingRepo.GetBookingNameByIdAsync(deleteReservationdto.BookingId); //Detta är fel
            if (booking == null)
            {
                return NotFound("Booking wasn't found");
            }

            await _bookingRepo.DeleteReservationAsync(booking);
            return Ok(true);
        }
        [HttpGet("GetBookingById")]
        [Authorize]
        public async Task<IActionResult> GetBookingDetailsFromId([FromBody] BookingNameViewModel bookingNameViewModel)
        {
            try
            {
                var result = _bookingRepo.GetBookingNameByIdAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
