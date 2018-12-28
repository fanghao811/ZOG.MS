namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12_29_Forget : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BD_InstrumentTest", new[] { "UserId" });
            AlterColumn("dbo.BD_InstrumentTest", "UserId", c => c.Long());
            CreateIndex("dbo.BD_InstrumentTest", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BD_InstrumentTest", new[] { "UserId" });
            AlterColumn("dbo.BD_InstrumentTest", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.BD_InstrumentTest", "UserId");
        }
    }
}
