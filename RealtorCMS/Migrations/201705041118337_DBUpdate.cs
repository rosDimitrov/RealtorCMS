namespace RealtorCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "IsFeatured");
        }
    }
}
