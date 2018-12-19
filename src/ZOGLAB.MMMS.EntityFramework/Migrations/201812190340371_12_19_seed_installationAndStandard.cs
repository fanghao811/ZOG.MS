namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12_19_seed_installationAndStandard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BD_Standard", "Mark", c => c.String(maxLength: 50));
            AlterColumn("dbo.BD_Installation", "ValidateDate", c => c.String(maxLength: 20));
            AlterColumn("dbo.BD_Standard", "TestRange", c => c.String(maxLength: 50));
            DropColumn("dbo.BD_Standard", "ForApprove");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BD_Standard", "ForApprove", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BD_Standard", "TestRange", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BD_Installation", "ValidateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BD_Standard", "Mark");
        }
    }
}
