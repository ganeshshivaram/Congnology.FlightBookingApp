namespace Cognology.FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberOfPassengersToBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "NumberOfPassengers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "NumberOfPassengers");
        }
    }
}
