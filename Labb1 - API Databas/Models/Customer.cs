using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string ReservationName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public Booking Bookings { get; set; }
        public int FK_BookingId { get; set; }


    }
}
