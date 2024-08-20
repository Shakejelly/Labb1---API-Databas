using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1___API_Databas.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
       
        public Table Table { get; set; }
        public Customer Customer { get; set; }
        public string Day { get; set; }

        public int TableAmount { get; set; }
    }
}
