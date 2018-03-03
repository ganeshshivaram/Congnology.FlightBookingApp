using AutoMapper;
using Cognology.FlightBookingApp.Dto;
using Cognology.FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Cognology.FlightBookingApp.Controllers.Api
{
    public class BookingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public BookingsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("api/booking/search")]
        [HttpPost]
        public IHttpActionResult SearchBooking(BookingSearchDto bookingSearchDto)
        {
            if (!ModelState.IsValid || bookingSearchDto == null)
            {
                return BadRequest("Invalid Request");
            }

            var bookingsQuery = _context.Bookings.Include(b => b.FlightInformation);

            if (bookingSearchDto.FlightNumber != null)
            {
                bookingsQuery = bookingsQuery
                                .Where(b => b.FlightInformation.FlightNumber == bookingSearchDto.FlightNumber);
            }

            if (bookingSearchDto.PassengerName != null)
            {
                bookingsQuery = bookingsQuery
                                .Where(b => b.PassengerName.ToLower().Contains(bookingSearchDto.PassengerName.ToLower()));
            }

            if (bookingSearchDto.Date != null)
            {
                bookingsQuery = bookingsQuery
                                .Where(b => b.Date == bookingSearchDto.Date);
            }

            if (bookingSearchDto.ArrivalCity != null)
            {
                bookingsQuery = bookingsQuery
                                .Where(b => b.FlightInformation.ArrivalCity.ToLower() == bookingSearchDto.ArrivalCity.ToLower());
            }

            if (bookingSearchDto.DepartureCity != null)
            {
                bookingsQuery = bookingsQuery
                                .Where(b => b.FlightInformation.DepartureCity.ToLower() == bookingSearchDto.DepartureCity.ToLower());
            }

            var bookings = bookingsQuery.ToList();

            return Ok(Mapper.Map<IEnumerable<Booking>, 
                IEnumerable<BookingWithFlightInformationDto>>(bookings));
        }


        [Route("api/booking/create")]
        [HttpPost]
        public IHttpActionResult CreateBooking(BookingDto bookingDto)
        {
            if (!ModelState.IsValid || bookingDto == null)
            {
                return BadRequest("Invalid Request");
            }

            var flight = _context.Flights
                         .Where(f => (f.FlightNumber == bookingDto.FlightNumber 
                            && f.StartTime == bookingDto.FlightStartTime 
                            && (f.AvailableSeats - bookingDto.NumberOfPassengers) >= 0))
                            .FirstOrDefault();

            if(flight == null)
            {
                return NotFound();
            }

            var bookingInfo = new Booking()
            {
                Date = DateTime.Now,
                PassengerName = bookingDto.PassengerName,
                NumberOfPassengers = bookingDto.NumberOfPassengers,
                FlightId = flight.Id
            };

            _context.Bookings.Add(bookingInfo);

            flight.AvailableSeats = flight.AvailableSeats - bookingDto.NumberOfPassengers;

            _context.SaveChanges();

            return Ok(true);
        }
    }
}
