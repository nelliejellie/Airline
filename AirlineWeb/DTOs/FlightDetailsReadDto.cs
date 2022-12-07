using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineWeb.DTOs
{
    public class FlightDetailsReadDto
    {
        
        public int Id { get; set; }
  
        public string FlightCode { get; set; }

        public decimal Price { get; set; }
    }
}
