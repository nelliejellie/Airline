using AutoMapper;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;

namespace AirlineWeb.Profiles
{
    public class WebhookSubscriptionProfileDto : Profile
    {
       
        public WebhookSubscriptionProfileDto()
        {
            CreateMap<WebHookSubscriptionCreateDto, WebhookSubscription>().ReverseMap();
            CreateMap<WebhookSubscription, WebhookSubscriptionReadDto>();
        }
    }
}
