using System.ComponentModel.DataAnnotations;

namespace AirlineWeb.DTOs
{
    public class WebHookSubscriptionCreateDto
    {
        [Required]
        public string WebhookUri { get; set; }
        [Required]
        public string WebhookType { get; set; }
    }
}
