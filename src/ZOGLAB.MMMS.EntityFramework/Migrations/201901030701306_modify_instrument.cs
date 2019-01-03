namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify_instrument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BD_InstrumentTest", "CaliValidate", c => c.String(maxLength: 20));
            DropColumn("dbo.BD_InstrumentTest", "CaliValidateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BD_InstrumentTest", "CaliValidateDate", c => c.String(maxLength: 20));
            DropColumn("dbo.BD_InstrumentTest", "CaliValidate");
        }
    }
}
