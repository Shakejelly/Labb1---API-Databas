using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Table
    {
        [Key] 
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }

    }
}
