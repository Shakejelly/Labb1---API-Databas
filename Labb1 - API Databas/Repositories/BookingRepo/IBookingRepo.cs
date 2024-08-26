using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repositories.BookingRepo
{
    public interface IBookingRepo
    {
        Task MakeReservationAsync(Booking booking);
        Task AddCustomerToReservationAsync(Customer customer, int tableAmount);
        Task DeleteReservationAsync(Booking booking);
        Task<ICollection<Booking>> GetBookings(int bookingid);
        Task<Booking> GetMenuOnBookingAsync(int menuId);
        Task<Booking> GetBookingNameByIdAsync(int bookingid);

    }
}
