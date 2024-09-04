﻿using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repositories.BookingRepo
{
    public interface IBookingRepo
    {
        Task MakeReservationAsync(Booking booking);

        Task DeleteReservationAsync(Booking booking);
        Task<ICollection<Booking>> GetBookings(int bookingId);
        Task<Booking> GetBookingNameByIdAsync(int bookingId);

    }
}
