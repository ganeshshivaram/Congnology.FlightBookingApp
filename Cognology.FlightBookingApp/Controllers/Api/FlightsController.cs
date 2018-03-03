using AutoMapper;
using Cognology.FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cognology.FlightBookingApp.Controllers.Api
{
    public class FlightsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FlightsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("api/getallflights")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            var flights = _context.Flights.ToList();

            return Ok(Mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(flights));
        }

        [Route("api/flight/checkavailability")]
        [HttpGet]
        public IHttpActionResult CheckAvailability(DateTime givenDate,
          DateTime endDate, uint noOfPassengers)
        {
            var flights = _context.Flights.AsEnumerable();
            var availabilityList = new List<Flight>();

            flights = flights.Where(f => f.StartTime > givenDate);

            flights = flights.Where(f => f.EndTime <= endDate);

            foreach(var flight in flights)
            {
                if((flight.AvailableSeats - noOfPassengers) >= 0)
                {
                    availabilityList.Add(flight);
                }
            }

            return Ok(Mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(availabilityList));
        }
    }
}
