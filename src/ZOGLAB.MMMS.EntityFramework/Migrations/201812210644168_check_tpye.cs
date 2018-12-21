namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class check_tpye : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BD_CalibrationType", newName: "BD_MeteorType");
            DropForeignKey("dbo.BD_CheckType", "CalibrationType_ID", "dbo.BD_CalibrationType");
            DropIndex("dbo.BD_CheckType", new[] { "CalibrationType_ID" });
            RenameColumn(table: "dbo.BD_CheckType", name: "CalibrationType_ID", newName: "MeteorType_ID");
            AlterTableAnnotations(
                "dbo.BD_MeteorType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BD_CalibrationType_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_BD_MeteorType_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.BD_MeteorType", "Name", c => c.String(maxLength: 20));
            AddColumn("dbo.BD_CheckType", "CalibrationType", c => c.Int(nullable: false));
            AlterColumn("dbo.BD_MeteorType", "Mark", c => c.String(maxLength: 50));
            AlterColumn("dbo.BD_CheckType", "MeteorType_ID", c => c.Long());
            CreateIndex("dbo.BD_CheckType", "MeteorType_ID");
            AddForeignKey("dbo.BD_CheckType", "MeteorType_ID", "dbo.BD_MeteorType", "Id");
            DropColumn("dbo.BD_MeteorType", "BackNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BD_MeteorType", "BackNumber", c => c.String());
            DropForeignKey("dbo.BD_CheckType", "MeteorType_ID", "dbo.BD_MeteorType");
            DropIndex("dbo.BD_CheckType", new[] { "MeteorType_ID" });
            AlterColumn("dbo.BD_CheckType", "MeteorType_ID", c => c.Long(nullable: false));
            AlterColumn("dbo.BD_MeteorType", "Mark", c => c.String());
            DropColumn("dbo.BD_CheckType", "CalibrationType");
            DropColumn("dbo.BD_MeteorType", "Name");
            AlterTableAnnotations(
                "dbo.BD_MeteorType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BD_CalibrationType_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_BD_MeteorType_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            RenameColumn(table: "dbo.BD_CheckType", name: "MeteorType_ID", newName: "CalibrationType_ID");
            CreateIndex("dbo.BD_CheckType", "CalibrationType_ID");
            AddForeignKey("dbo.BD_CheckType", "CalibrationType_ID", "dbo.BD_CalibrationType", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.BD_MeteorType", newName: "BD_CalibrationType");
        }
    }
}
