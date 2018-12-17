namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class added_BD_5_entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BD_Back",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BD_Receive_ID = c.Long(nullable: false),
                        BackNumber = c.Int(nullable: false),
                        Users = c.String(maxLength: 50),
                        Tel = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        ExpressDelivery = c.String(maxLength: 50),
                        Model = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Receive", t => t.BD_Receive_ID, cascadeDelete: true)
                .Index(t => t.BD_Receive_ID);
            
            CreateTable(
                "dbo.BD_Receive",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Unit_ID = c.Long(nullable: false),
                        Number = c.String(maxLength: 50),
                        Device_Num = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        FoundUser = c.String(maxLength: 50),
                        ExpressDelivery = c.String(maxLength: 50),
                        Model = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Receive_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_EssentialFactor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Instrument_ID = c.Long(nullable: false),
                        Name = c.String(maxLength: 20),
                        Model = c.Int(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Instrument", t => t.Instrument_ID, cascadeDelete: true)
                .Index(t => t.Instrument_ID);
            
            CreateTable(
                "dbo.BD_Instrument",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Site_ID = c.Long(nullable: false),
                        SN = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Model = c.String(maxLength: 50),
                        Grade = c.String(maxLength: 20),
                        Scope = c.String(maxLength: 20),
                        Power = c.String(maxLength: 20),
                        Manufacturer = c.String(maxLength: 50),
                        CheckType_ID = c.Int(nullable: false),
                        Mark = c.String(maxLength: 50),
                        isUsing = c.Int(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_ReceiveDevice",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BD_Receive_ID = c.Long(nullable: false),
                        Instrument_ID = c.Long(nullable: false),
                        UnitMark = c.String(maxLength: 50),
                        Back_ID = c.Int(nullable: false),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_ReceiveDevice_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Instrument", t => t.Instrument_ID, cascadeDelete: true)
                .ForeignKey("dbo.BD_Receive", t => t.BD_Receive_ID, cascadeDelete: true)
                .Index(t => t.BD_Receive_ID)
                .Index(t => t.Instrument_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BD_ReceiveDevice", "BD_Receive_ID", "dbo.BD_Receive");
            DropForeignKey("dbo.BD_ReceiveDevice", "Instrument_ID", "dbo.BD_Instrument");
            DropForeignKey("dbo.BD_EssentialFactor", "Instrument_ID", "dbo.BD_Instrument");
            DropForeignKey("dbo.BD_Back", "BD_Receive_ID", "dbo.BD_Receive");
            DropIndex("dbo.BD_ReceiveDevice", new[] { "Instrument_ID" });
            DropIndex("dbo.BD_ReceiveDevice", new[] { "BD_Receive_ID" });
            DropIndex("dbo.BD_EssentialFactor", new[] { "Instrument_ID" });
            DropIndex("dbo.BD_Back", new[] { "BD_Receive_ID" });
            DropTable("dbo.BD_ReceiveDevice",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_ReceiveDevice_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Instrument");
            DropTable("dbo.BD_EssentialFactor");
            DropTable("dbo.BD_Receive",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Receive_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Back");
        }
    }
}
