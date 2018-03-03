namespace Cognology.FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFlights : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Flights (FlightNumber, StartTime, EndTime, PassengerCapacity, DepartureCity, ArrivalCity) VALUES ('QF11', '2018-03-03 04:00:00.000', '2018-03-03 08:00:00.000', 10, 'Melbourne', 'Sydney')");
            Sql("INSERT INTO Flights (FlightNumber, StartTime, EndTime, PassengerCapacity, DepartureCity, ArrivalCity) VALUES ('QF11', '2018-03-04 04:00:00.000', '2018-03-04 08:00:00.000', 10, 'Melbourne', 'Sydney')");
            Sql("INSERT INTO Flights (FlightNumber, StartTime, EndTime, PassengerCapacity, DepartureCity, ArrivalCity) VALUES ('QF11', '2018-03-05 04:00:00.000', '2018-03-05 08:00:00.000', 10, 'Melbourne', 'Sydney')");
            Sql("INSERT INTO Flights (FlightNumber, StartTime, EndTime, PassengerCapacity, DepartureCity, ArrivalCity) VALUES ('QF11', '2018-03-06 04:00:00.000', '2018-03-06 08:00:00.000', 10, 'Melbourne', 'Sydney')");
            Sql("INSERT INTO Flights (FlightNumber, StartTime, EndTime, PassengerCapacity, DepartureCity, ArrivalCity) VALUES ('QF12', '2018-03-03 06:00:00.000', '2018-03-03 09:00:00.000', 10, 'Melbourne', 'Perth')");
            Sql("INSERT INTO Flights (FlightNumber, StartTime, EndTime, PassengerCapacity, DepartureCity, ArrivalCity) VALUES ('QF12', '2018-03-04 06:00:00.000', '2018-03-04 09:00:00.000', 10, 'Melbourne', 'Perth')");
        }
        
        public override void Down()
        {
        }
    }
}
