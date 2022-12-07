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
    public class FlightsController : ControllerBase
    {
        private readonly AirlineRepository _airlineRepository;
        private readonly IMapper _mapper;
        private readonly FlightsRepository _flightsRepository;

        public FlightsController(FlightsRepository flightsRepository, IMapper mapper)
        {
            _flightsRepository = flightsRepository;
            _mapper = mapper;
        }

        [HttpGet("{flightcode}", Name = "GetFlightDetailsByCode")]
        public ActionResult<FlightDetailsReadDto> GetFlightDetailsByCode(string code)
        {
            var flight = _flightsRepository.GetFlightDetailByCondition(x => x.FlightCode == code);

            if(flight == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
