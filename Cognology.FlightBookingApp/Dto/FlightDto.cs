using System;

namespace Cognology.FlightBookingApp.Models
{
    public class FlightDto
    {
        public string FlightNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PassengerCapacity { get; set; }
        public int AvailableSeats { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
    }
}