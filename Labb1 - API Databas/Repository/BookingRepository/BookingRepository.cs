using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.BookingDto;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repository.BookingRepository
{
    public class BookingRepository : IBookingRepository 
    {
        private readonly RestaurantContext _context;

        public BookingRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken cancellationToken)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Table)
                .ToListAsync();
                
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Table)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
            return booking;
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
    }
}
