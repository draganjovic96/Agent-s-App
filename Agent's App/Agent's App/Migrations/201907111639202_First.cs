namespace Agent_s_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
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
                        Address_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
