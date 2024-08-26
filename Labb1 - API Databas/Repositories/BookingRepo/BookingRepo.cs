﻿using Labb1___API_Databas.Data;
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
        public async Task AddCustomerToReservationAsync(Customer customer, int tableAmount)
        {
            try
            {
                var reservation = await _context.Bookings
                    .FirstOrDefaultAsync(r => r.TableAmount == tableAmount);
                if (reservation == null) 
                {
                    throw new Exception("Couldn't add the reservation.");
                }
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't add the reservation.");
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

        public async Task<Booking> GetBookingNameByIdAsync(int bookingid)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Booking>> GetBookings(int bookingid)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetMenuOnBookingAsync(int menuId)
        {
            throw new NotImplementedException();
        }

    }
}
