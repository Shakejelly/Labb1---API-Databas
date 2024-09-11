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

        public async Task<BookingGetDto> GetReservationByIdAsync(int bookingId, CancellationToken cancellationToken)
        {
            try
            {
                var reservation = await _repo.GetBookingByIdAsync(bookingId, cancellationToken);

                if (reservation == null)
                {
                    throw new Exception($"Reservation with ID {bookingId} not found.");
                }

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
            catch (Exception ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while retrieving the reservation.", ex);
            }
        }

        public async Task<IEnumerable<BookingGetDto>> GetAllReservationsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var reservations = await _repo.GetAllBookingsAsync(cancellationToken);

                var reservationList = reservations.Select(r => new BookingGetDto
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
            catch (Exception ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while retrieving all reservations.", ex);
            }
        }

        public async Task DeleteReservationAsync(int bookingId, CancellationToken cancellationToken)
        {
            try
            {
                var bookingFound = await _repo.GetBookingByIdAsync(bookingId, cancellationToken);

                if (bookingFound == null)
                {
                    throw new Exception($"Reservation with ID {bookingId} not found.");
                }

                await _repo.DeleteBookingAsync(bookingFound, cancellationToken);
            }
            catch (Exception ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while deleting the reservation.", ex);
            }
        }

        public async Task AddReservationAsync(BookingAddDto bookingAdd, CancellationToken cancellationToken)
        {
            try
            {
                var newReservation = new Booking
                {
                    FK_CustomerId = bookingAdd.CustomerId,
                    FK_TableNumber = bookingAdd.TableId,
                    BookingAmount = bookingAdd.BookingAmount,
                    TimeToArrive = bookingAdd.TimeToArrive,
                };

                await _repo.AddBookingAsync(newReservation, cancellationToken);
            }
            catch (Exception ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while adding the reservation.", ex);
            }
        }

        public async Task UpdateReservationAsync(BookingUpdateDto bookingUpdate, CancellationToken cancellationToken)
        {
            try
            {
                var bookingFound = await _repo.GetBookingByIdAsync(bookingUpdate.BookingId, cancellationToken);

                if (bookingFound == null)
                {
                    throw new Exception($"Reservation with ID {bookingUpdate.BookingId} not found.");
                }

                bookingFound.BookingAmount = bookingUpdate.BookingAmount;
                bookingFound.TimeToArrive = bookingUpdate.TimeToArrive;

                await _repo.UpdateBookingAsync(bookingFound, cancellationToken);
            }
            catch (Exception ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while updating the reservation.", ex);
            }
        }
    }
}
