using System;
using System.ComponentModel.DataAnnotations;

namespace Cognology.FlightBookingApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfPassengers { get; set; }

        public Flight FlightInformation { get; set; }

        [Required]
        public int FlightId { get; set; }
    }
}