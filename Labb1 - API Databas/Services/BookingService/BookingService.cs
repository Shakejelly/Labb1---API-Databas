using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.BookingDto;
using Labb1___API_Databas.Repository.BookingRepository;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repositories.BookingRepo
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;
        public BookingService(IBookingRepository repo)
        {
            _repo = repo;

        }

        public async Task<BookingGetDto> GetReservationByIdAsync(int bookingId)
        {
            var reservation = await _repo.GetBookingByIdAsync(bookingId);

            var reservationDto = new BookingGetDto
            {
                BookingId = reservation.BookingId,
                CustomerId = reservation.Customer.CustomerId,
                CustomerName = reservation.Customer.ReservationName,
                PhoneNumber = reservation.Customer.PhoneNumber,
                TableId = reservation.Table.TableId,
                SeatingsAmount = reservation.BookingAmount,
                TimeToArrive = reservation.TimeToArrive,
            };
            return reservationDto;
        }

        public async Task<IEnumerable<BookingGetDto>> GetAllReservationsAsync()
        {
            var reservation = await _repo.GetAllBookingsAsync();

            var reservationList = reservation.Select(r => new BookingGetDto
            {
                BookingId = r.BookingId,
                CustomerId = r.Customer.CustomerId,
                CustomerName = r.Customer.ReservationName,
                PhoneNumber = r.Customer.PhoneNumber,
                TableId = r.Table.TableId,
                SeatingsAmount = r.BookingAmount,
                TimeToArrive = r.TimeToArrive,
            }).ToList();
            return reservationList;

        }

        public async Task DeleteReservationAsync(int bookingId)
        {
            var bookingFound = await _repo.GetBookingByIdAsync(bookingId);

                if (bookingFound != null)
            {
                await _repo.DeleteBookingAsync(bookingFound);
            }
        }

        public async Task AddReservationAsync(BookingAddDto bookingAdd)
        {
            var newReservation = new Booking
            {
                FK_CustomerId = bookingAdd.CustomerId,
                FK_TableNumber = bookingAdd.TableId,
                BookingAmount = bookingAdd.BookingAmount,
                TimeToArrive = bookingAdd.TimeToArrive,

            };
            
            await _repo.AddBookingAsync(newReservation);
        }

        public async Task UpdateReservationAsync(BookingUpdateDto bookingUpdate)
        {
            var bookingFound = await _repo.GetBookingByIdAsync(bookingUpdate.BookingId);

            if(bookingFound != null)
            {
                bookingFound.BookingAmount = bookingUpdate.BookingAmount;
                bookingFound.TimeToArrive = bookingUpdate.TimeToArrive;

                await _repo.UpdateBookingAsync(bookingFound);
            }
        }
    }
}
