using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.BookingDto;

namespace Labb1___API_Databas.Repository.BookingRepository
{
    public interface IBookingRepository
    {
        Task DeleteBookingAsync(Booking bookingId);
        Task UpdateBookingAsync(Booking booking);
        Task AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int bookingId);
    }
}
