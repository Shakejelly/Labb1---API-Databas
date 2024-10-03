using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        public int Seatings { get; set; }
        public bool IsOccupied { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
