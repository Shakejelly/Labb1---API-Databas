using Labb1___API_Databas.Models.Dto.BookingDto;

namespace Labb1___API_Databas.Repositories.BookingRepo
{
    public interface IBookingService
    {
        Task DeleteReservationAsync(int bookingId);
        Task AddReservationAsync(BookingAddDto bookingAdd);
        Task UpdateReservationAsync(BookingUpdateDto bookingUpdate);
        Task<IEnumerable<BookingGetDto>> GetAllReservationsAsync();
        Task<BookingGetDto> GetReservationByIdAsync(int bookingId);

    }
}
