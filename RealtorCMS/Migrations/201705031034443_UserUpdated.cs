namespace RealtorCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
