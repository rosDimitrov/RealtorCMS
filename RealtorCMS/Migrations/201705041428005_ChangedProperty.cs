namespace RealtorCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Description", c => c.String());
            AddColumn("dbo.Properties", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Properties", "ImagePath", c => c.String());
            AddColumn("dbo.Properties", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Properties", "TextDescription");
            DropColumn("dbo.Properties", "PropertyPrice");
            DropColumn("dbo.Properties", "PropertlyImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "PropertlyImagePath", c => c.String());
            AddColumn("dbo.Properties", "PropertyPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Properties", "TextDescription", c => c.String());
            DropColumn("dbo.Properties", "CreateDate");
            DropColumn("dbo.Properties", "ImagePath");
            DropColumn("dbo.Properties", "Price");
            DropColumn("dbo.Properties", "Description");
        }
    }
}
