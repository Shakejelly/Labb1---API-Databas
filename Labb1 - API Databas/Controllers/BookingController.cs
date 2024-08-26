using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models.Dto;
using Labb1___API_Databas.Repositories.BookingRepo;
using Microsoft.AspNetCore.Mvc;
using Labb1___API_Databas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;

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
        public async Task<IActionResult> AddReservation([FromBody]AddCustomerDto addCustomerDto)
        {
            try
            {
            var newReservation = new Customer
            {
                ReservationName = addCustomerDto.ReservationName,
                PhoneNumber = addCustomerDto.PhoneNumber,
                Bookings = new Booking
                {
                    TableAmount = addCustomerDto.Booking.ReservationAmount,
                    TimeToArrive = addCustomerDto.Booking.BookingDate,
                   
                }

            };
            var result = await _bookingRepo.AddCustomerToReservationAsync(newReservation);
            await _bookingRepo.MakeReservationAsync(newReservation, addCustomerDto.Booking.ReservationAmount);
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
    }
}
