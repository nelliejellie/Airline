using AirlineWeb.Data;
using AirlineWeb.DTOs;
using AirlineWeb.Entity;
using AirlineWeb.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly FlightsRepository _flightsRepository;

        public FlightsController(FlightsRepository flightsRepository, IMapper mapper)
        {
            _flightsRepository = flightsRepository;
            _mapper = mapper;
        }

        [HttpGet("code",Name = "GetFlightDetailsByCoded")]
        public ActionResult<FlightDetailsReadDto> GetFlightDetailsByCoded([FromQuery]string code)
        {
            var flight = _flightsRepository.GetFlightDetailByCondition(x => x.FlightCode == code);

            if (flight == null)
            {
                return NotFound();
            }
            var flightRead = _mapper.Map<FlightDetailsReadDto>(flight);
            return Ok(flight);
        }


        [HttpGet(Name = "GetFlights")]
        public ActionResult<FlightDetailsReadDto> GetFlights()
        {
            var flight = _flightsRepository.GetFlightAllDetails();

            if (flight == null)
            {
                return NotFound();
            }
            var flightRead = _mapper.Map<ICollection<FlightDetailsReadDto>>(flight);
            return Ok(flightRead);
        }

        [HttpPost]
        public async Task<ActionResult> AddFlightDetails(FlightDetailsCreateDto flightDetailsCreateDto)
        {
            try
            {
                var newFlight =  _flightsRepository.GetFlightDetailByCondition(x => x.FlightCode == flightDetailsCreateDto.FlightCode);

                if (newFlight == null)
                {
                    newFlight = _mapper.Map<FlightDetail>(flightDetailsCreateDto);
                    await _flightsRepository.CreateFlight(newFlight);

                    return CreatedAtRoute(nameof(GetFlights), newFlight);
                }
                else
                {
                    return BadRequest("This Flightcode already exists");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFlightDetails(int id, FlightDetailsUpdateDto flightDetailUpdate)
        {
            var flight = _flightsRepository.GetFlightDetailByCondition(x => x.Id == id);
            if (flight == null)
            {
                return NoContent();
            }
            try
            {
                var newUpdatedFlight = await _flightsRepository.UpdateFlight(id, flightDetailUpdate);
                if (newUpdatedFlight)
                    return Ok("updated successfully");
                return BadRequest("not updated successfully");
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
