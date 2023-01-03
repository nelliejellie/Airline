using AirlineWeb.DTOs;
using AirlineWeb.Entity;
using AutoMapper;

namespace AirlineWeb.Profiles
{
    public class FlightDetailsProfile : Profile
    {
        public FlightDetailsProfile()
        {
            CreateMap<FlightDetail, FlightDetailsCreateDto>().ReverseMap();
            CreateMap<FlightDetail, FlightDetailsUpdateDto>().ReverseMap();
            CreateMap<FlightDetailsReadDto, FlightDetail>();
            CreateMap<FlightDetail, FlightDetailsReadDto>();
            
        }
    }
}
