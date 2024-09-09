using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repository.BookingRepository
{
    public interface IBookingRepository
    {
        Task DeleteBookingAsync(Booking booking, CancellationToken cancellationToken);
        Task UpdateBookingAsync(Booking booking, CancellationToken cancellationToken);
        Task AddBookingAsync(Booking booking, CancellationToken cancellationToken);
        Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken cancellationToken);
        Task<Booking> GetBookingByIdAsync(int bookingId, CancellationToken cancellationToken);
    }
}
