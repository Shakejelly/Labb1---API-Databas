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
            try
            {
                await _context.Bookings.AddAsync(booking, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga felet eller hantera det på ett passande sätt
                throw new Exception("An error occurred while adding the booking.", ex);
            }
            catch (Exception ex)
            {
                // Hantera generella fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public async Task DeleteBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            try
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga felet eller hantera det på ett passande sätt
                throw new Exception("An error occurred while deleting the booking.", ex);
            }
            catch (Exception ex)
            {
                // Hantera generella fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Bookings
                    .Include(b => b.Customer)
                    .Include(b => b.Table)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // Hantera fel vid hämtning av bokningar
                throw new Exception("An error occurred while retrieving bookings.", ex);
            }

        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId, CancellationToken cancellationToken)
        {
            try
            {
                var booking = await _context.Bookings
                    .Include(b => b.Customer)
                    .Include(b => b.Table)
                    .FirstOrDefaultAsync(b => b.BookingId == bookingId, cancellationToken);

                if (booking == null)
                {
                    throw new Exception($"Booking with ID {bookingId} not found.");
                }

                return booking;
            }
            catch (Exception ex)
            {
                // Hantera fel vid hämtning av bokning
                throw new Exception("An error occurred while retrieving the booking.", ex);
            }
        }
        public async Task UpdateBookingAsync(Booking booking, CancellationToken cancellationToken)

        {
            try
            {
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga felet eller hantera det på ett passande sätt
                throw new Exception("An error occurred while updating the booking.", ex);
            }
            catch (Exception ex)
            {
                // Hantera generella fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}    
