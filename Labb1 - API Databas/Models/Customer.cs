using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Booking Booking { get; set; }
        public ICollection<Booking> Bookings { get; set; }


    }
}
