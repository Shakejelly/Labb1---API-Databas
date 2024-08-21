﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1___API_Databas.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey("Table")]
        public int FK_TableId { get; set; }
        public Table Table { get; set; }

        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string TimeToArrive { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
        public int TableAmount { get; set; }
    }
}
