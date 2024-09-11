using Labb1___API_Databas.Models.Dto.BookingDto;

namespace Labb1___API_Databas.Repositories.BookingRepo
{
    public interface IBookingService
    {
        Task DeleteReservationAsync(int bookingId, CancellationToken cancellationToken);
        Task AddReservationAsync(BookingAddDto bookingAdd, CancellationToken cancellationToken);
        Task UpdateReservationAsync(BookingUpdateDto bookingUpdate, CancellationToken cancellationToken);
        Task<IEnumerable<BookingGetDto>> GetAllReservationsAsync(CancellationToken cancellationToken);
        Task<BookingGetDto> GetReservationByIdAsync(int bookingId, CancellationToken cancellationToken);

    }
}
