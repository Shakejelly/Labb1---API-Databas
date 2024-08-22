using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Table
    {
        [Key] 
        public int TableId { get; set; }
        [Required]
        public int TableNumber { get; set; }
        public int? Seatings { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
