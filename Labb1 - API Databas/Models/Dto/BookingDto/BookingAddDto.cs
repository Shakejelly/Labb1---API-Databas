namespace Labb1___API_Databas.Models.Dto.BookingDto
{
    public class BookingAddDto
    {
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public int BookingAmount { get; set; }
        public string TimeToArrive { get; set; }
    }
}
