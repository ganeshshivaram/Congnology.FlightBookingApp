using System;
using System.ComponentModel.DataAnnotations;

namespace Cognology.FlightBookingApp.Models
{
    public class BookingWithFlightInformationDto
    {
        public int BookingId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int NumberOfPassengers { get; set; }

        public int FlightId { get; set; }

        public FlightDto FlightInformation { get; set; }
    }
}