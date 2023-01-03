using AirlineWeb.Data;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirlineWeb.Repositories
{
    public class FlightsRepository
    {
        private readonly IMapper _mapper;
        private readonly AirlineDbContext _airlineDbContext;

        public FlightsRepository(AirlineDbContext airlineDbContext, IMapper mapper)
        {
            _airlineDbContext = airlineDbContext;
            _mapper = mapper;
        }

        public FlightDetail GetFlightDetailByCondition(Expression<Func<FlightDetail, bool>> expression)
        {
            var flight = _airlineDbContext.FlightDetails.FirstOrDefault(expression);

            return flight;
        }

        public List<FlightDetail> GetFlightAllDetails()
        {
            var flights = _airlineDbContext.FlightDetails.ToArray();

            return flights.ToList();
        }

        public async Task<bool> CreateFlight(FlightDetail flightDetail)
        {
            var newFlightDetails = await _airlineDbContext.AddAsync(flightDetail);

            var changes = await _airlineDbContext.SaveChangesAsync();

            return changes > 0;
        }

        public async Task<bool> UpdateFlight(int id, FlightDetailsUpdateDto flightDetailUpdate)
        {
            var flight = await _airlineDbContext.FlightDetails.FindAsync(id);
            if(flight == null)
            {
                return false;
            }
            var newFlight = _mapper.Map(flightDetailUpdate, flight);
            newFlight.Id = id;
            var changes = await _airlineDbContext.SaveChangesAsync();

            return changes > 0;
        }
    }
}
