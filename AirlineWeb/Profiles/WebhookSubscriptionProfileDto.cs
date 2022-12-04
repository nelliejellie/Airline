using AutoMapper;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;

namespace AirlineWeb.Profiles
{
    public class WebhookSubscriptionProfileDto : Profile
    {
       
        public WebhookSubscriptionProfileDto()
        {
            CreateMap<WebHookSubscriptionCreateDto, WebhookSubscription>();
            CreateMap<WebhookSubscription, WebhookSubscriptionReadDto>();
        }
    }
}
