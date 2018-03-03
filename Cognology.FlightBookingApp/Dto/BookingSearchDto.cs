using System;

namespace Cognology.FlightBookingApp.Dto
{
    public class BookingSearchDto
    {
        public string PassengerName { get; set; }
        public DateTime? Date { get; set; }
        public string FlightNumber { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
    }
}