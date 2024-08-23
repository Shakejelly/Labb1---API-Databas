﻿using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string BookingName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
