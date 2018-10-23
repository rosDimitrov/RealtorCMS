namespace RealtorCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyLists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Property_Id", "dbo.Properties");
            DropIndex("dbo.AspNetUsers", new[] { "Property_Id" });
            AddColumn("dbo.Properties", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Properties", "ApplicationUser_Id");
            AddForeignKey("dbo.Properties", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Property_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Property_Id", c => c.Int());
            DropForeignKey("dbo.Properties", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Properties", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Properties", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "Property_Id");
            AddForeignKey("dbo.AspNetUsers", "Property_Id", "dbo.Properties", "Id");
        }
    }
}
