namespace Labb1___API_Databas.Models.Dto
{
    public class AddCustomerDto
    {
        public string ReservationName { get; set; }
        public string PhoneNumber { get; set; }
        public AddReservationDto Booking { get; set; }
    }
}
