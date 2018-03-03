using AutoMapper;
using Cognology.FlightBookingApp.Models;

namespace Cognology.FlightBookingApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Flight, FlightDto>();
            Mapper.CreateMap<Booking, BookingWithFlightInformationDto>();
        }
    }
}