using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string BookingName { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
