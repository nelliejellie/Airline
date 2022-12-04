using AirlineWeb.Data;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AirlineWeb.Repositories
{
    public class AirlineRepository
    {
        private readonly AirlineDbContext _airlineDbContext;
        public AirlineRepository(AirlineDbContext airlineDbContext)
        {
            _airlineDbContext = airlineDbContext;
        }

        public bool Create(WebHookSubscriptionCreateDto webhookSubscription)
        {
            var subscription = _airlineDbContext.WebhookSubscriptions.FirstOrDefault(x => x.WebhookUri == webhookSubscription.WebhookUri);

            if(subscription == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
