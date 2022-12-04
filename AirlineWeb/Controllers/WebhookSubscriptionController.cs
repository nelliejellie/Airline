using AirlineWeb.Data;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;
using AirlineWeb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookSubscriptionController : ControllerBase
    {
        private readonly AirlineRepository _airlineRepository;

        public WebhookSubscriptionController(AirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        [HttpPost]
        public ActionResult<WebhookSubscriptionReadDto> CreateSubscription(WebHookSubscriptionCreateDto webHookSubscriptionCreateDto)
        {
            return Ok();
        }
    }
}
