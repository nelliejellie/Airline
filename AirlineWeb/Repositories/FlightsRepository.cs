using AirlineWeb.Data;
using AirlineWeb.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirlineWeb.Repositories
{
    public class FlightsRepository
    {
        private readonly AirlineDbContext _airlineDbContext;

        public FlightsRepository(AirlineDbContext airlineDbContext)
        {
            _airlineDbContext = airlineDbContext;
        }

        public async Task<FlightDetail> GetFlightDetailByCondition(Expression<Func<FlightDetail, bool>> expression)
        {
            var flight = await _airlineDbContext.FlightDetails.FirstOrDefaultAsync(expression);

            return flight;
        }
    }
}
