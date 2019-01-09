namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8_decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BD_TestItem", "EnvirTemp", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BD_TestItem", "EnvirHumidity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BD_TestItem", "EnvirPressure", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BD_TestItem", "EnvirPressure", c => c.String(maxLength: 20));
            AlterColumn("dbo.BD_TestItem", "EnvirHumidity", c => c.String(maxLength: 20));
            AlterColumn("dbo.BD_TestItem", "EnvirTemp", c => c.String(maxLength: 20));
        }
    }
}
