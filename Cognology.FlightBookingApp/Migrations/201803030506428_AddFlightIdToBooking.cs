namespace Cognology.FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlightIdToBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "FlightId", c => c.String(nullable: false));
            DropColumn("dbo.Bookings", "FlightNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "FlightNumber", c => c.String(nullable: false));
            DropColumn("dbo.Bookings", "FlightId");
        }
    }
}
