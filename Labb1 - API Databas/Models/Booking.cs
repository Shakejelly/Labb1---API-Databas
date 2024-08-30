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
        public int FK_TableNumber { get; set; }
        public Table Table { get; set; }

        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Menu")]
        public int FK_MenuId { get; set; }
        public Menu Menu { get; set; }
       
       
    }
}
