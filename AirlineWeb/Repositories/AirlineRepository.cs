using AirlineWeb.Data;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirlineWeb.Repositories
{
    public class AirlineRepository
    {
        private readonly AirlineDbContext _airlineDbContext;
        public AirlineRepository(AirlineDbContext airlineDbContext)
        {
            _airlineDbContext = airlineDbContext;
        }

        public async Task<bool> Create(WebhookSubscription webhookSubscription)
        {
            var sub = await _airlineDbContext.WebhookSubscriptions.AddAsync(webhookSubscription);
            var changes = await _airlineDbContext.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<WebhookSubscription> GetWebhookByCondition(Expression<Func<WebhookSubscription, bool>> expression)
        {
            var uri = _airlineDbContext.WebhookSubscriptions.FirstOrDefault(expression);
            if(uri == null)
            {
                return null;
            }
            return uri;

        }
    }
}
