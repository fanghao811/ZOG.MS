namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_BD_ets : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BD_Installatio", newName: "BD_Installation");
            CreateTable(
                "dbo.BD_CalibrationResult",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TestDevice_ID = c.Long(nullable: false),
                        IntDataID = c.Int(nullable: false),
                        StandVal = c.String(maxLength: 20),
                        StandRevisedVal = c.String(maxLength: 20),
                        StandReal = c.String(maxLength: 20),
                        ViewVal = c.String(maxLength: 20),
                        DiffPressVal = c.String(maxLength: 20),
                        CalibrationPointVal = c.String(maxLength: 20),
                        IntType = c.String(maxLength: 20),
                        IntCaliPointIndex = c.Int(nullable: false),
                        StrDateTime = c.DateTime(nullable: false),
                        CheckType = c.Boolean(nullable: false),
                        CheckFlag = c.Int(nullable: false),
                        Types = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestDevice", t => t.TestDevice_ID)
                .Index(t => t.TestDevice_ID);
            
            CreateTable(
                "dbo.BD_Standard",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FactoryNum = c.String(maxLength: 20),
                        SstrName = c.String(),
                        StrSpec = c.String(maxLength: 20),
                        Manufactor = c.String(maxLength: 50),
                        ManufactorTel = c.String(maxLength: 20),
                        CaliFactory = c.String(maxLength: 50),
                        CaliFactoryMan = c.String(maxLength: 20),
                        CaliFactoryTel = c.String(maxLength: 20),
                        Installation_ID = c.Long(nullable: false),
                        ResponsibleMan = c.String(maxLength: 20),
                        ValidateDate = c.DateTime(nullable: false),
                        TestRange = c.Boolean(nullable: false),
                        Accurate = c.DateTime(nullable: false),
                        StrK = c.String(maxLength: 20),
                        CertNum = c.String(maxLength: 50),
                        StrType = c.Boolean(nullable: false),
                        ForApprove = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        DeviceItem_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Installation", t => t.Installation_ID)
                .ForeignKey("dbo.BD_DeviceItem", t => t.DeviceItem_Id)
                .Index(t => t.Installation_ID)
                .Index(t => t.DeviceItem_Id);
            
            AddColumn("dbo.BD_Unit", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BD_Unit", "CreatorUserId", c => c.Long());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BD_Standard", "DeviceItem_Id", "dbo.BD_DeviceItem");
            DropForeignKey("dbo.BD_Standard", "Installation_ID", "dbo.BD_Installation");
            DropForeignKey("dbo.BD_CalibrationResult", "TestDevice_ID", "dbo.BD_TestDevice");
            DropIndex("dbo.BD_Standard", new[] { "DeviceItem_Id" });
            DropIndex("dbo.BD_Standard", new[] { "Installation_ID" });
            DropIndex("dbo.BD_CalibrationResult", new[] { "TestDevice_ID" });
            DropColumn("dbo.BD_Unit", "CreatorUserId");
            DropColumn("dbo.BD_Unit", "CreationTime");
            DropTable("dbo.BD_Standard");
            DropTable("dbo.BD_CalibrationResult");
            RenameTable(name: "dbo.BD_Installation", newName: "BD_Installatio");
        }
    }
}
