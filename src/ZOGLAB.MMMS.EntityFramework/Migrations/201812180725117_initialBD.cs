namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initialBD : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "UserId", "TenantId" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            DropIndex("dbo.AbpUserNotifications", new[] { "UserId", "State", "CreationTime" });
            CreateTable(
                "dbo.BD_Appendix",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TestDevice_ID = c.Long(nullable: false),
                        DeviceName = c.String(),
                        DeviceType = c.String(),
                        DeviceSN = c.String(),
                        UnitName = c.String(),
                        Address = c.String(),
                        IntType = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestDevice", t => t.TestDevice_ID, cascadeDelete: true)
                .Index(t => t.TestDevice_ID);
            
            CreateTable(
                "dbo.BD_TestDevice",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Test_ID = c.Long(nullable: false),
                        DeviceItem_ID = c.Long(nullable: false),
                        Instrument_ID = c.Long(nullable: false),
                        Check_User = c.String(maxLength: 50),
                        Check_DateTime = c.DateTime(nullable: false),
                        Check_Result = c.String(maxLength: 50),
                        Check_NGMark = c.String(maxLength: 50),
                        Appearance = c.String(maxLength: 20),
                        EnvirTemp = c.String(maxLength: 20),
                        EnvirHumidity = c.String(maxLength: 20),
                        EnvirPressure = c.String(maxLength: 20),
                        ForCheck = c.Boolean(nullable: false),
                        ForCheck_DateTime = c.DateTime(nullable: false),
                        ForCheck_User = c.String(maxLength: 20),
                        ForCheck_Result = c.String(maxLength: 20),
                        ForCheck_NGMark = c.String(maxLength: 50),
                        ForApprove = c.Boolean(nullable: false),
                        ForApprove_User = c.String(maxLength: 20),
                        ForApprove_DateTime = c.DateTime(nullable: false),
                        ForApprove_Result = c.String(maxLength: 20),
                        ForApprove_NGMark = c.String(maxLength: 20),
                        CertificateId = c.String(maxLength: 50),
                        RawRecordsetId = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_DeviceItem", t => t.DeviceItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.BD_Instrument", t => t.Instrument_ID, cascadeDelete: true)
                .ForeignKey("dbo.BD_Test", t => t.Test_ID, cascadeDelete: true)
                .Index(t => t.Test_ID)
                .Index(t => t.DeviceItem_ID)
                .Index(t => t.Instrument_ID);
            
            CreateTable(
                "dbo.BD_DeviceItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IntHandover = c.Boolean(nullable: false),
                        UserId = c.Long(nullable: false),
                        Calibration = c.Boolean(nullable: false),
                        CheckFlag = c.Boolean(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        IntReCaliFlag = c.Boolean(nullable: false),
                        Number = c.String(maxLength: 50),
                        CaliValidateDate = c.DateTime(nullable: false),
                        CaliU95 = c.String(maxLength: 50),
                        AlterReason = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        StrFlag = c.Boolean(nullable: false),
                        ProcessEnd = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BD_ReceiveDevice_Id = c.Long(),
                        BD_Test_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_ReceiveDevice", t => t.BD_ReceiveDevice_Id)
                .ForeignKey("dbo.BD_Test", t => t.BD_Test_Id)
                .ForeignKey("dbo.AbpUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BD_ReceiveDevice_Id)
                .Index(t => t.BD_Test_Id);
            
            CreateTable(
                "dbo.BD_ReceiveDevice",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReceiveDevice_ID = c.Long(nullable: false),
                        Instrument_ID = c.Long(nullable: false),
                        UnitMark = c.String(maxLength: 50),
                        Back_ID = c.Int(nullable: false),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Instrument", t => t.Instrument_ID, cascadeDelete: true)
                .ForeignKey("dbo.BD_ReceiveDevice", t => t.ReceiveDevice_ID)
                .Index(t => t.ReceiveDevice_ID)
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
                        IsUsing = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_Test",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Installation_ID = c.Long(nullable: false),
                        Check_Num = c.String(maxLength: 50),
                        Check_Type = c.String(maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        Site_ID = c.Int(nullable: false),
                        VocationalWorkType = c.Int(nullable: false),
                        Mark = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Installation", t => t.Installation_ID, cascadeDelete: true)
                .Index(t => t.Installation_ID);
            
            CreateTable(
                "dbo.BD_Installation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Standard_SN = c.String(maxLength: 20),
                        Equipment_Name = c.String(maxLength: 50),
                        Equipment_Model = c.String(),
                        TestRange = c.String(maxLength: 50),
                        Accurate = c.String(maxLength: 50),
                        CertificateId = c.String(maxLength: 50),
                        ValidateDate = c.DateTime(nullable: false),
                        Organization = c.String(maxLength: 50),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_Back",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Receive_ID = c.Long(nullable: false),
                        BackNumber = c.Int(nullable: false),
                        Users = c.String(maxLength: 50),
                        Tel = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        ExpressDelivery = c.String(maxLength: 50),
                        BackModel = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_ReceiveDevice", t => t.Receive_ID, cascadeDelete: true)
                .Index(t => t.Receive_ID);
            
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
                .ForeignKey("dbo.BD_TestDevice", t => t.TestDevice_ID, cascadeDelete: true)
                .Index(t => t.TestDevice_ID);
            
            CreateTable(
                "dbo.BD_CalibrationType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BackNumber = c.String(),
                        Mark = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_CheckType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalibrationType_ID = c.Long(nullable: false),
                        CheckName = c.String(maxLength: 20),
                        Mark = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 50),
                        StrDateTime = c.DateTime(nullable: false),
                        StrFlag = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_CalibrationType", t => t.CalibrationType_ID, cascadeDelete: true)
                .Index(t => t.CalibrationType_ID);
            
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
                "dbo.BD_Rainfall",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TestDevice_ID = c.Long(nullable: false),
                        IntDataID = c.Int(nullable: false),
                        StandVal = c.String(maxLength: 20),
                        StandRevisedVal = c.String(maxLength: 50),
                        StandReal = c.String(maxLength: 20),
                        ViewVal = c.String(maxLength: 20),
                        DiffPressVal = c.String(maxLength: 20),
                        IntType = c.String(maxLength: 20),
                        IntCaliPointIndex = c.Int(nullable: false),
                        StrDateTime = c.DateTime(nullable: false),
                        CheckType = c.Boolean(nullable: false),
                        Types = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestDevice", t => t.TestDevice_ID, cascadeDelete: true)
                .Index(t => t.TestDevice_ID);
            
            CreateTable(
                "dbo.BD_Randiation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TestDevice_ID = c.Long(nullable: false),
                        IntDataID = c.Int(nullable: false),
                        MaxVal = c.String(maxLength: 20),
                        MaxVZeroValal = c.String(maxLength: 20),
                        Val = c.String(maxLength: 20),
                        T1 = c.String(maxLength: 20),
                        T2 = c.String(maxLength: 20),
                        T3 = c.String(maxLength: 20),
                        Tbegin = c.String(maxLength: 20),
                        Tend = c.String(maxLength: 20),
                        MaxVaRESl = c.String(maxLength: 20),
                        Wind = c.String(maxLength: 20),
                        IntType = c.Boolean(nullable: false),
                        CheckType = c.Boolean(nullable: false),
                        Types = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestDevice", t => t.TestDevice_ID, cascadeDelete: true)
                .Index(t => t.TestDevice_ID);
            
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
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_Remission",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Receive_ID = c.Long(nullable: false),
                        UserName = c.String(maxLength: 20),
                        StrDateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_ReceiveDevice", t => t.Receive_ID, cascadeDelete: true)
                .Index(t => t.Receive_ID);
            
            CreateTable(
                "dbo.BD_Rules",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RuleId = c.String(maxLength: 20),
                        Address = c.String(maxLength: 20),
                        StrDateTime = c.DateTime(nullable: false),
                        StrJobDoc = c.String(maxLength: 50),
                        FilePath = c.String(maxLength: 50),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_Site",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrganizationUnit_ID = c.Long(nullable: false),
                        Users = c.String(maxLength: 20),
                        SiteName = c.String(maxLength: 20),
                        ProvinceName = c.String(maxLength: 20),
                        Longitude = c.String(maxLength: 20),
                        Latitude = c.String(maxLength: 20),
                        Address = c.String(maxLength: 50),
                        NumCount = c.Int(nullable: false),
                        IntType = c.Boolean(nullable: false),
                        BackNumber = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpOrganizationUnits", t => t.OrganizationUnit_ID, cascadeDelete: true)
                .Index(t => t.OrganizationUnit_ID);
            
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
                .ForeignKey("dbo.BD_Installation", t => t.Installation_ID, cascadeDelete: true)
                .ForeignKey("dbo.BD_DeviceItem", t => t.DeviceItem_Id)
                .Index(t => t.Installation_ID)
                .Index(t => t.DeviceItem_Id);
            
            CreateTable(
                "dbo.BD_Unit",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UnitName = c.String(maxLength: 50),
                        Address = c.String(),
                        Users = c.String(maxLength: 50),
                        Tel = c.String(),
                        Email = c.String(maxLength: 20),
                        FaxNumber = c.String(maxLength: 20),
                        Mark = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_Visibility",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TestDevice_ID = c.Long(nullable: false),
                        IntDataID = c.Int(nullable: false),
                        StandReal = c.String(maxLength: 20),
                        ViewVal = c.String(maxLength: 20),
                        DiffPressVal = c.String(maxLength: 20),
                        IntType = c.Boolean(nullable: false),
                        CheckType = c.Boolean(nullable: false),
                        Types = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestDevice", t => t.TestDevice_ID, cascadeDelete: true)
                .Index(t => t.TestDevice_ID);
            
            CreateTable(
                "dbo.BD_Wind",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TestDevice_ID = c.Int(nullable: false),
                        IntDataID = c.Int(nullable: false),
                        StandVal = c.String(maxLength: 20),
                        StandRevisedVal = c.String(maxLength: 20),
                        StandReal = c.String(maxLength: 20),
                        ViewVal = c.String(maxLength: 20),
                        DiffPressVal = c.String(maxLength: 20),
                        CalibrationPointVal = c.String(maxLength: 20),
                        StrViewVal = c.String(maxLength: 20),
                        StrStandVal = c.String(maxLength: 20),
                        StrKVal = c.String(maxLength: 20),
                        StrbVal = c.String(maxLength: 20),
                        EnvirTempVal1 = c.String(maxLength: 20),
                        EnvirTempVal2 = c.String(maxLength: 20),
                        EnvirHumVal1 = c.String(maxLength: 20),
                        EnvirHumVal2 = c.String(maxLength: 20),
                        EnvirPressVal1 = c.String(maxLength: 20),
                        EnvirPressVal2 = c.String(maxLength: 20),
                        DiffPressVal1 = c.String(maxLength: 20),
                        DiffPressVal2 = c.String(maxLength: 20),
                        IntType = c.String(maxLength: 20),
                        IntCaliPointIndex = c.Int(nullable: false),
                        StrDateTime = c.String(maxLength: 20),
                        CheckType = c.Int(nullable: false),
                        Types = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_WindDirection",
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
                        StrViewVal = c.String(maxLength: 20),
                        StrStandVal = c.String(maxLength: 20),
                        StrKVal = c.String(maxLength: 20),
                        StrbVal = c.String(maxLength: 20),
                        EnvirTempVal1 = c.String(maxLength: 20),
                        EnvirTempVal2 = c.String(maxLength: 20),
                        EnvirHumVal1 = c.String(maxLength: 20),
                        EnvirHumVal2 = c.String(maxLength: 20),
                        EnvirPressVal1 = c.String(maxLength: 20),
                        EnvirPressVal2 = c.String(maxLength: 20),
                        IntType = c.String(maxLength: 20),
                        IntCaliPointIndex = c.Int(nullable: false),
                        StrDateTime = c.String(maxLength: 20),
                        CheckType = c.Int(nullable: false),
                        Types = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestDevice", t => t.TestDevice_ID, cascadeDelete: true)
                .Index(t => t.TestDevice_ID);
            
            AlterTableAnnotations(
                "dbo.AbpAuditLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        ServiceName = c.String(maxLength: 256),
                        MethodName = c.String(maxLength: 256),
                        Parameters = c.String(maxLength: 1024),
                        ExecutionTime = c.DateTime(nullable: false),
                        ExecutionDuration = c.Int(nullable: false),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        BrowserInfo = c.String(maxLength: 256),
                        Exception = c.String(maxLength: 2000),
                        ImpersonatorUserId = c.Long(),
                        ImpersonatorTenantId = c.Int(),
                        CustomData = c.String(maxLength: 2000),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_AuditLog_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AppBinaryObjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        Bytes = c.Binary(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinaryObject_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AppChatMessages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        TenantId = c.Int(),
                        TargetUserId = c.Long(nullable: false),
                        TargetTenantId = c.Int(),
                        Message = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Side = c.Int(nullable: false),
                        ReadState = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ChatMessage_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpFeatures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Value = c.String(nullable: false, maxLength: 2000),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        EditionId = c.Int(),
                        TenantId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TenantFeatureSetting_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpEditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Edition_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AppFriendships",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        TenantId = c.Int(),
                        FriendUserId = c.Long(nullable: false),
                        FriendTenantId = c.Int(),
                        FriendUserName = c.String(nullable: false, maxLength: 32),
                        FriendTenancyName = c.String(),
                        FriendProfilePictureId = c.Guid(),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Friendship_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 10),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        Icon = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationLanguage_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_ApplicationLanguage_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpLanguageTexts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        LanguageName = c.String(nullable: false, maxLength: 10),
                        Source = c.String(nullable: false, maxLength: 128),
                        Key = c.String(nullable: false, maxLength: 256),
                        Value = c.String(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationLanguageText_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpNotificationSubscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        NotificationName = c.String(maxLength: 96),
                        EntityTypeName = c.String(maxLength: 250),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512),
                        EntityId = c.String(maxLength: 96),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        ParentId = c.Long(),
                        Code = c.String(nullable: false, maxLength: 95),
                        DisplayName = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_OrganizationUnit_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_OrganizationUnit_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpPermissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128),
                        IsGranted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        UserId = c.Long(),
                        RoleId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_PermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_RolePermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_UserPermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        IsStatic = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 32),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Role_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_Role_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProfilePictureId = c.Guid(),
                        ShouldChangePasswordOnNextLogin = c.Boolean(nullable: false),
                        AuthenticationSource = c.String(maxLength: 64),
                        Name = c.String(nullable: false, maxLength: 32),
                        Surname = c.String(nullable: false, maxLength: 32),
                        Password = c.String(nullable: false, maxLength: 128),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        EmailConfirmationCode = c.String(maxLength: 328),
                        PasswordResetCode = c.String(maxLength: 328),
                        LockoutEndDateUtc = c.DateTime(),
                        AccessFailedCount = c.Int(nullable: false),
                        IsLockoutEnabled = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        IsPhoneNumberConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        IsTwoFactorEnabled = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 32),
                        TenantId = c.Int(),
                        EmailAddress = c.String(nullable: false, maxLength: 256),
                        LastLoginTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_User_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_User_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserClaims",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserClaim_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserLogins",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 256),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserLogin_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserRole_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        Name = c.String(nullable: false, maxLength: 256),
                        Value = c.String(maxLength: 2000),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Setting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SD_Function_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SD_MenuTreeUnit_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SD_Report_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpTenantNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        NotificationName = c.String(nullable: false, maxLength: 96),
                        Data = c.String(),
                        DataTypeName = c.String(maxLength: 512),
                        EntityTypeName = c.String(maxLength: 250),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512),
                        EntityId = c.String(maxLength: 96),
                        Severity = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TenantNotificationInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpTenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomCssId = c.Guid(),
                        LogoId = c.Guid(),
                        LogoFileType = c.String(maxLength: 64),
                        EditionId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        TenancyName = c.String(nullable: false, maxLength: 64),
                        ConnectionString = c.String(maxLength: 1024),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Tenant_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TreeUnit_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        UserLinkId = c.Long(),
                        UserName = c.String(),
                        EmailAddress = c.String(),
                        LastLoginTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserAccount_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserLoginAttempts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        TenancyName = c.String(maxLength: 64),
                        UserId = c.Long(),
                        UserNameOrEmailAddress = c.String(maxLength: 255),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        BrowserInfo = c.String(maxLength: 256),
                        Result = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserLoginAttempt_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        TenantNotificationId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserNotificationInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserOrganizationUnit_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BD_WindDirection", "TestDevice_ID", "dbo.BD_TestDevice");
            DropForeignKey("dbo.BD_Visibility", "TestDevice_ID", "dbo.BD_TestDevice");
            DropForeignKey("dbo.BD_Standard", "DeviceItem_Id", "dbo.BD_DeviceItem");
            DropForeignKey("dbo.BD_Standard", "Installation_ID", "dbo.BD_Installation");
            DropForeignKey("dbo.BD_Site", "OrganizationUnit_ID", "dbo.AbpOrganizationUnits");
            DropForeignKey("dbo.BD_Remission", "Receive_ID", "dbo.BD_ReceiveDevice");
            DropForeignKey("dbo.BD_Randiation", "TestDevice_ID", "dbo.BD_TestDevice");
            DropForeignKey("dbo.BD_Rainfall", "TestDevice_ID", "dbo.BD_TestDevice");
            DropForeignKey("dbo.BD_EssentialFactor", "Instrument_ID", "dbo.BD_Instrument");
            DropForeignKey("dbo.BD_CheckType", "CalibrationType_ID", "dbo.BD_CalibrationType");
            DropForeignKey("dbo.BD_CalibrationResult", "TestDevice_ID", "dbo.BD_TestDevice");
            DropForeignKey("dbo.BD_Back", "Receive_ID", "dbo.BD_ReceiveDevice");
            DropForeignKey("dbo.BD_Appendix", "TestDevice_ID", "dbo.BD_TestDevice");
            DropForeignKey("dbo.BD_TestDevice", "Test_ID", "dbo.BD_Test");
            DropForeignKey("dbo.BD_TestDevice", "Instrument_ID", "dbo.BD_Instrument");
            DropForeignKey("dbo.BD_TestDevice", "DeviceItem_ID", "dbo.BD_DeviceItem");
            DropForeignKey("dbo.BD_DeviceItem", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.BD_DeviceItem", "BD_Test_Id", "dbo.BD_Test");
            DropForeignKey("dbo.BD_Test", "Installation_ID", "dbo.BD_Installation");
            DropForeignKey("dbo.BD_DeviceItem", "BD_ReceiveDevice_Id", "dbo.BD_ReceiveDevice");
            DropForeignKey("dbo.BD_ReceiveDevice", "ReceiveDevice_ID", "dbo.BD_ReceiveDevice");
            DropForeignKey("dbo.BD_ReceiveDevice", "Instrument_ID", "dbo.BD_Instrument");
            DropIndex("dbo.BD_WindDirection", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Visibility", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Standard", new[] { "DeviceItem_Id" });
            DropIndex("dbo.BD_Standard", new[] { "Installation_ID" });
            DropIndex("dbo.BD_Site", new[] { "OrganizationUnit_ID" });
            DropIndex("dbo.BD_Remission", new[] { "Receive_ID" });
            DropIndex("dbo.BD_Randiation", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Rainfall", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_EssentialFactor", new[] { "Instrument_ID" });
            DropIndex("dbo.BD_CheckType", new[] { "CalibrationType_ID" });
            DropIndex("dbo.BD_CalibrationResult", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Back", new[] { "Receive_ID" });
            DropIndex("dbo.BD_Test", new[] { "Installation_ID" });
            DropIndex("dbo.BD_ReceiveDevice", new[] { "Instrument_ID" });
            DropIndex("dbo.BD_ReceiveDevice", new[] { "ReceiveDevice_ID" });
            DropIndex("dbo.BD_DeviceItem", new[] { "BD_Test_Id" });
            DropIndex("dbo.BD_DeviceItem", new[] { "BD_ReceiveDevice_Id" });
            DropIndex("dbo.BD_DeviceItem", new[] { "UserId" });
            DropIndex("dbo.BD_TestDevice", new[] { "Instrument_ID" });
            DropIndex("dbo.BD_TestDevice", new[] { "DeviceItem_ID" });
            DropIndex("dbo.BD_TestDevice", new[] { "Test_ID" });
            DropIndex("dbo.BD_Appendix", new[] { "TestDevice_ID" });
            AlterTableAnnotations(
                "dbo.AbpUserOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserOrganizationUnit_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        TenantNotificationId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserNotificationInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserLoginAttempts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        TenancyName = c.String(maxLength: 64),
                        UserId = c.Long(),
                        UserNameOrEmailAddress = c.String(maxLength: 255),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        BrowserInfo = c.String(maxLength: 256),
                        Result = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserLoginAttempt_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        UserLinkId = c.Long(),
                        UserName = c.String(),
                        EmailAddress = c.String(),
                        LastLoginTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserAccount_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TreeUnit_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpTenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomCssId = c.Guid(),
                        LogoId = c.Guid(),
                        LogoFileType = c.String(maxLength: 64),
                        EditionId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        TenancyName = c.String(nullable: false, maxLength: 64),
                        ConnectionString = c.String(maxLength: 1024),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Tenant_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpTenantNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        NotificationName = c.String(nullable: false, maxLength: 96),
                        Data = c.String(),
                        DataTypeName = c.String(maxLength: 512),
                        EntityTypeName = c.String(maxLength: 250),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512),
                        EntityId = c.String(maxLength: 96),
                        Severity = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TenantNotificationInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SD_Report_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SD_MenuTreeUnit_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SD_Function_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        Name = c.String(nullable: false, maxLength: 256),
                        Value = c.String(maxLength: 2000),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Setting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserRole_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserLogins",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 256),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserLogin_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUserClaims",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UserClaim_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProfilePictureId = c.Guid(),
                        ShouldChangePasswordOnNextLogin = c.Boolean(nullable: false),
                        AuthenticationSource = c.String(maxLength: 64),
                        Name = c.String(nullable: false, maxLength: 32),
                        Surname = c.String(nullable: false, maxLength: 32),
                        Password = c.String(nullable: false, maxLength: 128),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        EmailConfirmationCode = c.String(maxLength: 328),
                        PasswordResetCode = c.String(maxLength: 328),
                        LockoutEndDateUtc = c.DateTime(),
                        AccessFailedCount = c.Int(nullable: false),
                        IsLockoutEnabled = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        IsPhoneNumberConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        IsTwoFactorEnabled = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 32),
                        TenantId = c.Int(),
                        EmailAddress = c.String(nullable: false, maxLength: 256),
                        LastLoginTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_User_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_User_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        IsStatic = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 32),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Role_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_Role_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpPermissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128),
                        IsGranted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        UserId = c.Long(),
                        RoleId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_PermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_RolePermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_UserPermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        ParentId = c.Long(),
                        Code = c.String(nullable: false, maxLength: 95),
                        DisplayName = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_OrganizationUnit_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_OrganizationUnit_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpNotificationSubscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        NotificationName = c.String(maxLength: 96),
                        EntityTypeName = c.String(maxLength: 250),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512),
                        EntityId = c.String(maxLength: 96),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpLanguageTexts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        LanguageName = c.String(nullable: false, maxLength: 10),
                        Source = c.String(nullable: false, maxLength: 128),
                        Key = c.String(nullable: false, maxLength: 256),
                        Value = c.String(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationLanguageText_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 10),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        Icon = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationLanguage_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_ApplicationLanguage_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AppFriendships",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        TenantId = c.Int(),
                        FriendUserId = c.Long(nullable: false),
                        FriendTenantId = c.Int(),
                        FriendUserName = c.String(nullable: false, maxLength: 32),
                        FriendTenancyName = c.String(),
                        FriendProfilePictureId = c.Guid(),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Friendship_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpEditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Edition_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpFeatures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Value = c.String(nullable: false, maxLength: 2000),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        EditionId = c.Int(),
                        TenantId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TenantFeatureSetting_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AppChatMessages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        TenantId = c.Int(),
                        TargetUserId = c.Long(nullable: false),
                        TargetTenantId = c.Int(),
                        Message = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Side = c.Int(nullable: false),
                        ReadState = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ChatMessage_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AppBinaryObjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        Bytes = c.Binary(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinaryObject_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AbpAuditLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        ServiceName = c.String(maxLength: 256),
                        MethodName = c.String(maxLength: 256),
                        Parameters = c.String(maxLength: 1024),
                        ExecutionTime = c.DateTime(nullable: false),
                        ExecutionDuration = c.Int(nullable: false),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        BrowserInfo = c.String(maxLength: 256),
                        Exception = c.String(maxLength: 2000),
                        ImpersonatorUserId = c.Long(),
                        ImpersonatorTenantId = c.Int(),
                        CustomData = c.String(maxLength: 2000),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_AuditLog_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            DropTable("dbo.BD_WindDirection");
            DropTable("dbo.BD_Wind");
            DropTable("dbo.BD_Visibility");
            DropTable("dbo.BD_Unit");
            DropTable("dbo.BD_Standard");
            DropTable("dbo.BD_Site");
            DropTable("dbo.BD_Rules");
            DropTable("dbo.BD_Remission");
            DropTable("dbo.BD_Receive");
            DropTable("dbo.BD_Randiation");
            DropTable("dbo.BD_Rainfall");
            DropTable("dbo.BD_EssentialFactor");
            DropTable("dbo.BD_CheckType");
            DropTable("dbo.BD_CalibrationType");
            DropTable("dbo.BD_CalibrationResult");
            DropTable("dbo.BD_Back");
            DropTable("dbo.BD_Installation");
            DropTable("dbo.BD_Test");
            DropTable("dbo.BD_Instrument");
            DropTable("dbo.BD_ReceiveDevice");
            DropTable("dbo.BD_DeviceItem");
            DropTable("dbo.BD_TestDevice");
            DropTable("dbo.BD_Appendix");
            CreateIndex("dbo.AbpUserNotifications", new[] { "UserId", "State", "CreationTime" });
            CreateIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            CreateIndex("dbo.AbpUserLoginAttempts", new[] { "UserId", "TenantId" });
            CreateIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            CreateIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
        }
    }
}
