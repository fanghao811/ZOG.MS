namespace ZOGLAB.MMMS.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class added_12_entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SD_Function",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        Name = c.String(maxLength: 50),
                        Parent_ID = c.Long(nullable: false),
                        FormPath = c.String(maxLength: 100),
                        PageUrl = c.String(maxLength: 100),
                        IconPath = c.String(maxLength: 100),
                        IsWinForm = c.Boolean(nullable: false),
                        IsWebForm = c.Boolean(nullable: false),
                        IsMobileForm = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 100),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        Type = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SD_Function_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_MenuTreeUnit",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CodeUnitLength = c.Int(nullable: false),
                        ParentId = c.Long(),
                        Code = c.String(nullable: false, maxLength: 29),
                        DisplayName = c.String(nullable: false, maxLength: 128),
                        Url = c.String(nullable: false),
                        Icon = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SD_MenuTreeUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_Organization",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        Name = c.String(maxLength: 50),
                        ParentOrg_ID = c.Long(nullable: false),
                        Address = c.String(maxLength: 200),
                        Tel = c.String(maxLength: 50),
                        Contact = c.String(maxLength: 50),
                        ServerIP = c.String(maxLength: 50),
                        ServerName = c.String(maxLength: 50),
                        IsLocalSystem = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_Parameter",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                        Memo = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_Report",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        ReportType = c.Int(nullable: false),
                        ReportPath = c.String(maxLength: 50),
                        ReportParams = c.Int(nullable: false),
                        RoleId = c.Long(),
                        RoleName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 200),
                        Memo = c.String(maxLength: 200),
                        CreationTime = c.DateTime(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SD_Report_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_RoleFunction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Role_ID = c.Long(nullable: false),
                        Function_ID = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        SD_Function_Id = c.Long(),
                        SD_Role_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SD_Function", t => t.SD_Function_Id)
                .ForeignKey("dbo.SD_Role", t => t.SD_Role_Id)
                .Index(t => t.SD_Function_Id)
                .Index(t => t.SD_Role_Id);
            
            CreateTable(
                "dbo.SD_Role",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        Name = c.String(maxLength: 50),
                        IsAdmin = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 100),
                        Memo = c.String(maxLength: 100),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_System",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Url = c.String(maxLength: 50),
                        DatabaseName = c.String(maxLength: 20),
                        UserName = c.String(maxLength: 50),
                        UserPwd = c.String(maxLength: 50),
                        IsShow = c.Boolean(nullable: false),
                        Memo = c.String(maxLength: 200),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_UIModel",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PageCode = c.String(maxLength: 200),
                        EntityCode = c.String(maxLength: 200),
                        Code = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        DataType = c.Int(nullable: false),
                        OperateDevice = c.String(),
                        OperateIP = c.String(maxLength: 20),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SD_UserLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ActionType = c.String(maxLength: 20),
                        ActionPage = c.String(maxLength: 50),
                        ActionContent = c.String(maxLength: 200),
                        User_ID = c.Long(nullable: false),
                        OperatorName = c.String(maxLength: 50),
                        OperateDevice = c.String(),
                        OperateIP = c.String(maxLength: 20),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SD_User", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.SD_User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(),
                        Role_ID = c.Long(),
                        Code = c.String(maxLength: 20),
                        Name = c.String(maxLength: 50),
                        Org_ID = c.Long(nullable: false),
                        Sex = c.String(maxLength: 10),
                        DepartName = c.String(maxLength: 100),
                        Pwd = c.String(maxLength: 50),
                        Tel = c.String(maxLength: 20),
                        IsLeader = c.Boolean(nullable: false),
                        Memo = c.String(maxLength: 100),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SD_Role", t => t.Role_ID)
                .ForeignKey("dbo.AbpUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.SD_UserRole",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Role_ID = c.Long(nullable: false),
                        User_ID = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SD_Role", t => t.Role_ID, cascadeDelete: true)
                .ForeignKey("dbo.SD_User", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.SD_Util",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TableCode = c.String(maxLength: 50),
                        TableColumn = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Prefix = c.String(maxLength: 10),
                        Length = c.Int(nullable: false),
                        KeyIndex = c.Int(nullable: false),
                        KeyValue = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                        Memo = c.String(maxLength: 200),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TreeUnit",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParentId = c.Long(),
                        Code = c.String(nullable: false, maxLength: 29),
                        DisplayName = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TreeUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SD_UserRole", "User_ID", "dbo.SD_User");
            DropForeignKey("dbo.SD_UserRole", "Role_ID", "dbo.SD_Role");
            DropForeignKey("dbo.SD_UserLog", "User_ID", "dbo.SD_User");
            DropForeignKey("dbo.SD_User", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.SD_User", "Role_ID", "dbo.SD_Role");
            DropForeignKey("dbo.SD_RoleFunction", "SD_Role_Id", "dbo.SD_Role");
            DropForeignKey("dbo.SD_RoleFunction", "SD_Function_Id", "dbo.SD_Function");
            DropIndex("dbo.SD_UserRole", new[] { "User_ID" });
            DropIndex("dbo.SD_UserRole", new[] { "Role_ID" });
            DropIndex("dbo.SD_User", new[] { "Role_ID" });
            DropIndex("dbo.SD_User", new[] { "UserId" });
            DropIndex("dbo.SD_UserLog", new[] { "User_ID" });
            DropIndex("dbo.SD_RoleFunction", new[] { "SD_Role_Id" });
            DropIndex("dbo.SD_RoleFunction", new[] { "SD_Function_Id" });
            DropTable("dbo.TreeUnit",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TreeUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.SD_Util");
            DropTable("dbo.SD_UserRole");
            DropTable("dbo.SD_User");
            DropTable("dbo.SD_UserLog");
            DropTable("dbo.SD_UIModel");
            DropTable("dbo.SD_System");
            DropTable("dbo.SD_Role");
            DropTable("dbo.SD_RoleFunction");
            DropTable("dbo.SD_Report",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SD_Report_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.SD_Parameter");
            DropTable("dbo.SD_Organization");
            DropTable("dbo.SD_MenuTreeUnit",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SD_MenuTreeUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.SD_Function",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SD_Function_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
