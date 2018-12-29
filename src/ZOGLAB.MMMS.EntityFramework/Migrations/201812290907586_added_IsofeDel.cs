namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class added_IsofeDel : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.BD_ReceiveInstrument",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Instrument_ID = c.Long(nullable: false),
                        Receive_ID = c.Long(nullable: false),
                        UnitMark = c.String(maxLength: 50),
                        Back_ID = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BD_ReceiveInstrument_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.BD_Test",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Installation_ID = c.Long(),
                        Check_Num = c.String(maxLength: 50),
                        MeteorType_ID = c.Long(),
                        StartDate = c.DateTime(),
                        FinishDate = c.DateTime(),
                        Site_ID = c.Int(nullable: false),
                        VocationalWorkType = c.Int(nullable: false),
                        Mark = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BD_Test_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.BD_ReceiveInstrument", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.BD_Test", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BD_Test", "IsDeleted");
            DropColumn("dbo.BD_ReceiveInstrument", "IsDeleted");
            AlterTableAnnotations(
                "dbo.BD_Test",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Installation_ID = c.Long(),
                        Check_Num = c.String(maxLength: 50),
                        MeteorType_ID = c.Long(),
                        StartDate = c.DateTime(),
                        FinishDate = c.DateTime(),
                        Site_ID = c.Int(nullable: false),
                        VocationalWorkType = c.Int(nullable: false),
                        Mark = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BD_Test_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.BD_ReceiveInstrument",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Instrument_ID = c.Long(nullable: false),
                        Receive_ID = c.Long(nullable: false),
                        UnitMark = c.String(maxLength: 50),
                        Back_ID = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BD_ReceiveInstrument_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
