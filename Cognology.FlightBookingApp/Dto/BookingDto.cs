using System;
using System.ComponentModel.DataAnnotations;

namespace Cognology.FlightBookingApp.Dto
{
    public class BookingDto
    {
        [Required]
        public string PassengerName { get; set; }

        [Required]
        public int NumberOfPassengers { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public DateTime FlightStartTime { get; set; }
    }
}