namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_seed_checkType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BD_Unit", "Contact", c => c.String(maxLength: 50));
            AddColumn("dbo.BD_Unit", "ContactTel", c => c.String());
            AlterColumn("dbo.BD_Unit", "Mark", c => c.String(maxLength: 50));
            DropColumn("dbo.BD_Unit", "Users");
            DropColumn("dbo.BD_Unit", "Tel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BD_Unit", "Tel", c => c.String());
            AddColumn("dbo.BD_Unit", "Users", c => c.String(maxLength: 50));
            AlterColumn("dbo.BD_Unit", "Mark", c => c.Boolean(nullable: false));
            DropColumn("dbo.BD_Unit", "ContactTel");
            DropColumn("dbo.BD_Unit", "Contact");
        }
    }
}
