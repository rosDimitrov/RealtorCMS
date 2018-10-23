namespace RealtorCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PicturePath = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Address = c.String(),
                        PropertyType = c.Int(nullable: false),
                        SquareFeet = c.Int(nullable: false),
                        NumberOfBaths = c.Int(nullable: false),
                        NumberOfBeds = c.Int(nullable: false),
                        TextDescription = c.String(),
                        PropertyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PropertlyImagePath = c.String(),
                        MapLink = c.String(),
                        YouTubeLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Property_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Property_Id");
            AddForeignKey("dbo.AspNetUsers", "Property_Id", "dbo.Properties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Property_Id", "dbo.Properties");
            DropIndex("dbo.AspNetUsers", new[] { "Property_Id" });
            DropColumn("dbo.AspNetUsers", "Property_Id");
            DropTable("dbo.Properties");
            DropTable("dbo.Blogs");
        }
    }
}
