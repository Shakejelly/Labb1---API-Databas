using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repositories.BookingRepo
{
    public class BookingRepo : IBookingRepo
    {
        private readonly RestaurantContext _context;
        public BookingRepo(RestaurantContext context)
        {
            _context = context;
        
        }
        public async Task AddCustomerToReservationAsync(Customer customer)
        {
            try
            {
              _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception)
            {
                throw new Exception("Couldn't add the customer.");
            }
        }
        public async Task MakeReservationAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();


            }
            catch (Exception)
            {
                throw new Exception("Couldn't add the reservation.");
            }
        }

        public async Task DeleteReservationAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't delete the reservation.");
            }

        }

        public async Task<Booking> GetBookingNameByIdAsync(int bookingId)
        {
            var result = await _context.Bookings
                .Where(r => r.BookingId == bookingId)
                .FirstOrDefaultAsync();
            return result;
        }

        public Task<ICollection<Booking>> GetBookings(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetMenuOnBookingAsync(int menuId)
        {
            throw new NotImplementedException();
        }

    }
}
