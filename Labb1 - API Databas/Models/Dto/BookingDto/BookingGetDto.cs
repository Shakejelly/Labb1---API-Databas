namespace Labb1___API_Databas.Models.Dto.BookingDto
{
    public class BookingGetDto
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int SeatingsAmount { get; set; }
        public DateTime TimeToArrive { get; set; }
    }
}
