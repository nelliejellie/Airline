﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineWeb.Entity
{
    public class FlightDetail
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FlightCode { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        [Required]
        public decimal Price { get; set; }
    }
}