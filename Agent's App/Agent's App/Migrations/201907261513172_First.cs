namespace Agent_s_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Description = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        AccommodationType = c.Int(nullable: false),
                        Address_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.AccommodationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Floor = c.Int(nullable: false),
                        Number = c.String(nullable: false),
                        NumberOfBeds = c.Int(nullable: false),
                        DefaultPrice = c.Double(nullable: false),
                        Accommodation_Id = c.Long(nullable: false),
                        AccommodationUnitType_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.Accommodation_Id, cascadeDelete: true)
                .ForeignKey("dbo.AccommodationUnitTypes", t => t.AccommodationUnitType_Id, cascadeDelete: true)
                .Index(t => t.Accommodation_Id)
                .Index(t => t.AccommodationUnitType_Id);
            
            CreateTable(
                "dbo.AccommodationUnitTypes",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeriodPrices",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        AccommodationUnit_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccommodationUnits", t => t.AccommodationUnit_Id, cascadeDelete: true)
                .Index(t => t.AccommodationUnit_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                        AgentConfirmed = c.Boolean(nullable: false),
                        AccommodationUnit_Id = c.Long(nullable: false),
                        Guest_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccommodationUnits", t => t.AccommodationUnit_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Guest_Id)
                .Index(t => t.AccommodationUnit_Id)
                .Index(t => t.Guest_Id);
            
            CreateTable(
                "dbo.CommentRates",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ApprovedComment = c.Boolean(nullable: false),
                        ContentOfComment = c.String(),
                        CommentDateTime = c.DateTime(nullable: false),
                        Ocena = c.Int(nullable: false),
                        RateImage = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Role = c.Int(nullable: false),
                        BusinessRegistrationNumber = c.Long(nullable: false),
                        Address_Id = c.Long(nullable: false),
                        AgentOfAccommodation_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accommodations", t => t.AgentOfAccommodation_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.AgentOfAccommodation_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Street = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        ApartmentNumber = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        MessageContent = c.String(),
                        Seen = c.Boolean(nullable: false),
                        DatumVreme = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Accommodation_Id = c.Long(),
                        Receiver_Id = c.Long(),
                        Reservation_Id = c.Long(),
                        Sender_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.Accommodation_Id)
                .ForeignKey("dbo.Users", t => t.Receiver_Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .Index(t => t.Accommodation_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Reservation_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.AccommodationServices",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccommodationServiceAccommodations",
                c => new
                    {
                        AccommodationService_Id = c.Long(nullable: false),
                        Accommodation_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccommodationService_Id, t.Accommodation_Id })
                .ForeignKey("dbo.AccommodationServices", t => t.AccommodationService_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accommodations", t => t.Accommodation_Id, cascadeDelete: true)
                .Index(t => t.AccommodationService_Id)
                .Index(t => t.Accommodation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccommodationServiceAccommodations", "Accommodation_Id", "dbo.Accommodations");
            DropForeignKey("dbo.AccommodationServiceAccommodations", "AccommodationService_Id", "dbo.AccommodationServices");
            DropForeignKey("dbo.Accommodations", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Accommodation_Id", "dbo.Accommodations");
            DropForeignKey("dbo.Reservations", "Guest_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "AgentOfAccommodation_Id", "dbo.Accommodations");
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.CommentRates", "Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "AccommodationUnit_Id", "dbo.AccommodationUnits");
            DropForeignKey("dbo.PeriodPrices", "AccommodationUnit_Id", "dbo.AccommodationUnits");
            DropForeignKey("dbo.AccommodationUnits", "AccommodationUnitType_Id", "dbo.AccommodationUnitTypes");
            DropForeignKey("dbo.AccommodationUnits", "Accommodation_Id", "dbo.Accommodations");
            DropIndex("dbo.AccommodationServiceAccommodations", new[] { "Accommodation_Id" });
            DropIndex("dbo.AccommodationServiceAccommodations", new[] { "AccommodationService_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Reservation_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropIndex("dbo.Messages", new[] { "Accommodation_Id" });
            DropIndex("dbo.Users", new[] { "AgentOfAccommodation_Id" });
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropIndex("dbo.CommentRates", new[] { "Id" });
            DropIndex("dbo.Reservations", new[] { "Guest_Id" });
            DropIndex("dbo.Reservations", new[] { "AccommodationUnit_Id" });
            DropIndex("dbo.PeriodPrices", new[] { "AccommodationUnit_Id" });
            DropIndex("dbo.AccommodationUnits", new[] { "AccommodationUnitType_Id" });
            DropIndex("dbo.AccommodationUnits", new[] { "Accommodation_Id" });
            DropIndex("dbo.Accommodations", new[] { "Address_Id" });
            DropTable("dbo.AccommodationServiceAccommodations");
            DropTable("dbo.AccommodationServices");
            DropTable("dbo.Messages");
            DropTable("dbo.Addresses");
            DropTable("dbo.Users");
            DropTable("dbo.CommentRates");
            DropTable("dbo.Reservations");
            DropTable("dbo.PeriodPrices");
            DropTable("dbo.AccommodationUnitTypes");
            DropTable("dbo.AccommodationUnits");
            DropTable("dbo.Accommodations");
        }
    }
}
