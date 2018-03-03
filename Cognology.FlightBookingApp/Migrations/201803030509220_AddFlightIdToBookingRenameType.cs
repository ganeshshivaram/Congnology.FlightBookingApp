namespace Cognology.FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlightIdToBookingRenameType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "FlightInformation_Id", "dbo.Flights");
            DropIndex("dbo.Bookings", new[] { "FlightInformation_Id" });
            DropColumn("dbo.Bookings", "FlightId");
            RenameColumn(table: "dbo.Bookings", name: "FlightInformation_Id", newName: "FlightId");
            AlterColumn("dbo.Bookings", "FlightId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "FlightId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "FlightId");
            AddForeignKey("dbo.Bookings", "FlightId", "dbo.Flights", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "FlightId", "dbo.Flights");
            DropIndex("dbo.Bookings", new[] { "FlightId" });
            AlterColumn("dbo.Bookings", "FlightId", c => c.Int());
            AlterColumn("dbo.Bookings", "FlightId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Bookings", name: "FlightId", newName: "FlightInformation_Id");
            AddColumn("dbo.Bookings", "FlightId", c => c.String(nullable: false));
            CreateIndex("dbo.Bookings", "FlightInformation_Id");
            AddForeignKey("dbo.Bookings", "FlightInformation_Id", "dbo.Flights", "Id");
        }
    }
}
