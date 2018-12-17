namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_properties_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "Sex", c => c.String(maxLength: 20));
            AddColumn("dbo.AbpUsers", "IsLeader", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "Memo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "Memo");
            DropColumn("dbo.AbpUsers", "IsLeader");
            DropColumn("dbo.AbpUsers", "Sex");
        }
    }
}
