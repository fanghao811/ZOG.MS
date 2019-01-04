namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test_SiteID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BD_Test", "Site_ID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BD_Test", "Site_ID", c => c.Int(nullable: false));
        }
    }
}
