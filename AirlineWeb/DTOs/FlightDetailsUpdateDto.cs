using System.ComponentModel.DataAnnotations;

namespace AirlineWeb.DTOs
{
    public class FlightDetailsUpdateDto
    {

        [Required]
        public string FlightCode { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
