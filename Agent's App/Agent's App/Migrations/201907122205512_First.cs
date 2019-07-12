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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccommodationUnits", "AccommodationUnitType_Id", "dbo.AccommodationUnitTypes");
            DropForeignKey("dbo.AccommodationUnits", "Accommodation_Id", "dbo.Accommodations");
            DropForeignKey("dbo.Users", "AgentOfAccommodation_Id", "dbo.Accommodations");
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Accommodations", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.AccommodationUnits", new[] { "AccommodationUnitType_Id" });
            DropIndex("dbo.AccommodationUnits", new[] { "Accommodation_Id" });
            DropIndex("dbo.Users", new[] { "AgentOfAccommodation_Id" });
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropIndex("dbo.Accommodations", new[] { "Address_Id" });
            DropTable("dbo.AccommodationUnitTypes");
            DropTable("dbo.AccommodationUnits");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
            DropTable("dbo.Accommodations");
        }
    }
}
