namespace Cognology.FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableSeatsToFlightEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "AvailableSeats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "AvailableSeats");
        }
    }
}
