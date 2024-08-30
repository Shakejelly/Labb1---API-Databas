namespace Labb1___API_Databas.Models.Dto
{
    public class AddReservationDto
    {
   
        public int ReservationAmount { get; set; }
        public string BookingDate {  get; set; }
       
        AddCustomerDto Customer { get; set; }
        
    }
}
