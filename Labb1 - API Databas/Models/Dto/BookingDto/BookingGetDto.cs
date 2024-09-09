namespace Labb1___API_Databas.Models.Dto.BookingDto
{
    public class BookingGetDto
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int TableId { get; set; }
        public int SeatingsAmount { get; set; }
        public string TimeToArrive { get; set; }
    }
}
