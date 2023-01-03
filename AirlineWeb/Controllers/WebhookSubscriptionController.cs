using AirlineWeb.Data;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;
using AirlineWeb.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AirlineWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookSubscriptionController : ControllerBase
    {
        private readonly AirlineRepository _airlineRepository;
        private readonly IMapper _mapper;

        public WebhookSubscriptionController(AirlineRepository airlineRepository, IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }

        [HttpGet(Name ="GetSubscriptionBySecret")]
        public ActionResult<WebhookSubscriptionReadDto> GetSubscriptionBySecret(string secret)
        {
            var subscription = _airlineRepository.GetWebhookByCondition(x => x.Secret == secret);
            if (subscription == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WebhookSubscriptionReadDto>(subscription));
        }

        [HttpPost]
        public async Task<ActionResult<WebhookSubscriptionReadDto>> CreateSubscription(WebHookSubscriptionCreateDto webHookSubscriptionCreateDto)
        {
            var subscription = await _airlineRepository.GetWebhookByCondition(x => x.WebhookUri == webHookSubscriptionCreateDto.WebhookUri);

            if (subscription == null)
            {
                subscription =  _mapper.Map<WebhookSubscription>(webHookSubscriptionCreateDto);
                subscription.Secret = Guid.NewGuid().ToString();
                subscription.WebhookPublisher = "Emeke Airlines";
                try
                {
                    _airlineRepository.Create(subscription);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
                var readDto = _mapper.Map<WebhookSubscriptionReadDto>(subscription);

                return Ok(readDto);
            }
            else
            {
                return NoContent();
            }
        }

        private ActionResult<WebhookSubscriptionReadDto> Created(object value, WebhookSubscriptionReadDto readDto)
        {
            throw new NotImplementedException();
        }
    }
}
