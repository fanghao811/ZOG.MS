namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initialSeeds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Appendix_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestItem", t => t.TestDevice_ID)
                .Index(t => t.TestDevice_ID);
            
            CreateTable(
                "dbo.BD_TestItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Test_ID = c.Long(nullable: false),
                        InstrumentTest_ID = c.Long(nullable: false),
                        Instrument_ID = c.Long(),
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_TestItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Instrument", t => t.Instrument_ID)
                .ForeignKey("dbo.BD_InstrumentTest", t => t.InstrumentTest_ID)
                .ForeignKey("dbo.BD_Test", t => t.Test_ID)
                .Index(t => t.Test_ID)
                .Index(t => t.InstrumentTest_ID)
                .Index(t => t.Instrument_ID);
            
            CreateTable(
                "dbo.BD_Instrument",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Site_ID = c.Long(),
                        SN = c.String(maxLength: 50),
                        Name = c.String(maxLength: 20),
                        Model = c.String(maxLength: 50),
                        Grade = c.String(maxLength: 20),
                        Scope = c.String(maxLength: 20),
                        Power = c.String(maxLength: 20),
                        Manufacturer = c.String(maxLength: 50),
                        Mark = c.String(maxLength: 50),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        BD_CheckType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_CheckType", t => t.BD_CheckType_Id)
                .Index(t => t.BD_CheckType_Id);
            
            CreateTable(
                "dbo.BD_CheckType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MeteorTypeId = c.Long(),
                        CalibrationType = c.Int(nullable: false),
                        CheckName = c.String(maxLength: 20),
                        Mark = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 20),
                        StrDateTime = c.DateTime(),
                        StrFlag = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_CheckType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_MeteorType", t => t.MeteorTypeId)
                .Index(t => t.MeteorTypeId);
            
            CreateTable(
                "dbo.BD_MeteorType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_MeteorType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BD_InstrumentTest",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReceiveInstrument_ID = c.Long(),
                        Test_ID = c.Long(),
                        CheckType_ID = c.Long(),
                        IntHandover = c.Boolean(nullable: false),
                        UserId = c.Long(nullable: false),
                        Calibration = c.Boolean(nullable: false),
                        CheckFlag = c.Boolean(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        IntReCaliFlag = c.Boolean(nullable: false),
                        Number = c.String(maxLength: 50),
                        CaliValidateDate = c.String(maxLength: 20),
                        CaliU = c.String(maxLength: 20),
                        AlterReason = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        StrFlag = c.Boolean(nullable: false),
                        ProcessEnd = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_InstrumentTest_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_CheckType", t => t.CheckType_ID)
                .ForeignKey("dbo.BD_ReceiveInstrument", t => t.ReceiveInstrument_ID)
                .ForeignKey("dbo.BD_Test", t => t.Test_ID)
                .ForeignKey("dbo.AbpUsers", t => t.UserId)
                .Index(t => t.ReceiveInstrument_ID)
                .Index(t => t.Test_ID)
                .Index(t => t.CheckType_ID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BD_ReceiveInstrument",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Instrument_ID = c.Long(nullable: false),
                        Receive_ID = c.Long(nullable: false),
                        UnitMark = c.String(maxLength: 50),
                        Back_ID = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Instrument", t => t.Instrument_ID)
                .ForeignKey("dbo.BD_Receive", t => t.Receive_ID)
                .Index(t => t.Instrument_ID)
                .Index(t => t.Receive_ID);
            
            CreateTable(
                "dbo.BD_Receive",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Unit_ID = c.Long(),
                        Number = c.String(maxLength: 50),
                        Device_Num = c.Int(),
                        Address = c.String(maxLength: 50),
                        Contact = c.String(maxLength: 50),
                        ContactTel = c.String(maxLength: 20),
                        ExpressDelivery = c.String(maxLength: 50),
                        Model = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Receive_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Unit", t => t.Unit_ID)
                .Index(t => t.Unit_ID);
            
            CreateTable(
                "dbo.BD_Unit",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UnitName = c.String(maxLength: 50),
                        Address = c.String(),
                        Contact = c.String(maxLength: 50),
                        ContactTel = c.String(),
                        Email = c.String(maxLength: 20),
                        FaxNumber = c.String(maxLength: 20),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Unit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
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
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Installation", t => t.Installation_ID)
                .ForeignKey("dbo.BD_MeteorType", t => t.MeteorType_ID)
                .Index(t => t.Installation_ID)
                .Index(t => t.MeteorType_ID);
            
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
                        ValidateDate = c.String(maxLength: 20),
                        Organization = c.String(maxLength: 50),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Installation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Back_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Receive", t => t.Receive_ID)
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_CalibrationResult_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestItem", t => t.TestDevice_ID)
                .Index(t => t.TestDevice_ID);
            
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Rainfall_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestItem", t => t.TestDevice_ID)
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Randiation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestItem", t => t.TestDevice_ID)
                .Index(t => t.TestDevice_ID);
            
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Remission_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_Receive", t => t.Receive_ID)
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Rules_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Site_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpOrganizationUnits", t => t.OrganizationUnit_ID)
                .Index(t => t.OrganizationUnit_ID);
            
            CreateTable(
                "dbo.BD_Standard",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FactoryNum = c.String(maxLength: 20),
                        StrName = c.String(),
                        StrSpec = c.String(maxLength: 20),
                        Manufactor = c.String(maxLength: 50),
                        ManufactorTel = c.String(maxLength: 20),
                        CaliFactory = c.String(maxLength: 50),
                        CaliFactoryMan = c.String(maxLength: 20),
                        CaliFactoryTel = c.String(maxLength: 20),
                        Installation_ID = c.Long(),
                        ResponsibleMan = c.String(maxLength: 20),
                        ValidateDate = c.DateTime(nullable: false),
                        TestRange = c.String(maxLength: 50),
                        Accurate = c.String(maxLength: 20),
                        StrK = c.String(maxLength: 20),
                        CertNum = c.String(maxLength: 50),
                        StrType = c.Boolean(nullable: false),
                        Mark = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        DeviceItem_Id = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Standard_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_InstrumentTest", t => t.DeviceItem_Id)
                .ForeignKey("dbo.BD_Installation", t => t.Installation_ID)
                .Index(t => t.Installation_ID)
                .Index(t => t.DeviceItem_Id);
            
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Visibility_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestItem", t => t.TestDevice_ID)
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Wind_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
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
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_WindDirection_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BD_TestItem", t => t.TestDevice_ID)
                .Index(t => t.TestDevice_ID);
            
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
                .ForeignKey("dbo.SD_User", t => t.User_ID)
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
                .ForeignKey("dbo.SD_Role", t => t.Role_ID)
                .ForeignKey("dbo.SD_User", t => t.User_ID)
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
            
            CreateTable(
                "dbo.InstrumentCheckType",
                c => new
                    {
                        InstrumentId = c.Long(nullable: false),
                        CheckTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstrumentId, t.CheckTypeId })
                .ForeignKey("dbo.BD_Instrument", t => t.InstrumentId)
                .ForeignKey("dbo.BD_CheckType", t => t.CheckTypeId)
                .Index(t => t.InstrumentId)
                .Index(t => t.CheckTypeId);
            
            CreateTable(
                "dbo.InstrumentMeteorType",
                c => new
                    {
                        InstrumentId = c.Long(nullable: false),
                        MeteorTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstrumentId, t.MeteorTypeId })
                .ForeignKey("dbo.BD_Instrument", t => t.InstrumentId)
                .ForeignKey("dbo.BD_MeteorType", t => t.MeteorTypeId)
                .Index(t => t.InstrumentId)
                .Index(t => t.MeteorTypeId);
            
            AddColumn("dbo.AbpUsers", "Sex", c => c.String(maxLength: 20));
            AddColumn("dbo.AbpUsers", "IsLeader", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "Memo", c => c.String(maxLength: 100));
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id");
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id");
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.SD_UserRole", "User_ID", "dbo.SD_User");
            DropForeignKey("dbo.SD_UserRole", "Role_ID", "dbo.SD_Role");
            DropForeignKey("dbo.SD_UserLog", "User_ID", "dbo.SD_User");
            DropForeignKey("dbo.SD_User", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.SD_User", "Role_ID", "dbo.SD_Role");
            DropForeignKey("dbo.SD_RoleFunction", "SD_Role_Id", "dbo.SD_Role");
            DropForeignKey("dbo.SD_RoleFunction", "SD_Function_Id", "dbo.SD_Function");
            DropForeignKey("dbo.BD_WindDirection", "TestDevice_ID", "dbo.BD_TestItem");
            DropForeignKey("dbo.BD_Visibility", "TestDevice_ID", "dbo.BD_TestItem");
            DropForeignKey("dbo.BD_Standard", "Installation_ID", "dbo.BD_Installation");
            DropForeignKey("dbo.BD_Standard", "DeviceItem_Id", "dbo.BD_InstrumentTest");
            DropForeignKey("dbo.BD_Site", "OrganizationUnit_ID", "dbo.AbpOrganizationUnits");
            DropForeignKey("dbo.BD_Remission", "Receive_ID", "dbo.BD_Receive");
            DropForeignKey("dbo.BD_Randiation", "TestDevice_ID", "dbo.BD_TestItem");
            DropForeignKey("dbo.BD_Rainfall", "TestDevice_ID", "dbo.BD_TestItem");
            DropForeignKey("dbo.BD_CalibrationResult", "TestDevice_ID", "dbo.BD_TestItem");
            DropForeignKey("dbo.BD_Back", "Receive_ID", "dbo.BD_Receive");
            DropForeignKey("dbo.BD_Appendix", "TestDevice_ID", "dbo.BD_TestItem");
            DropForeignKey("dbo.BD_TestItem", "Test_ID", "dbo.BD_Test");
            DropForeignKey("dbo.BD_TestItem", "InstrumentTest_ID", "dbo.BD_InstrumentTest");
            DropForeignKey("dbo.BD_InstrumentTest", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.BD_InstrumentTest", "Test_ID", "dbo.BD_Test");
            DropForeignKey("dbo.BD_Test", "MeteorType_ID", "dbo.BD_MeteorType");
            DropForeignKey("dbo.BD_Test", "Installation_ID", "dbo.BD_Installation");
            DropForeignKey("dbo.BD_InstrumentTest", "ReceiveInstrument_ID", "dbo.BD_ReceiveInstrument");
            DropForeignKey("dbo.BD_ReceiveInstrument", "Receive_ID", "dbo.BD_Receive");
            DropForeignKey("dbo.BD_Receive", "Unit_ID", "dbo.BD_Unit");
            DropForeignKey("dbo.BD_ReceiveInstrument", "Instrument_ID", "dbo.BD_Instrument");
            DropForeignKey("dbo.BD_InstrumentTest", "CheckType_ID", "dbo.BD_CheckType");
            DropForeignKey("dbo.BD_TestItem", "Instrument_ID", "dbo.BD_Instrument");
            DropForeignKey("dbo.InstrumentMeteorType", "MeteorTypeId", "dbo.BD_MeteorType");
            DropForeignKey("dbo.InstrumentMeteorType", "InstrumentId", "dbo.BD_Instrument");
            DropForeignKey("dbo.InstrumentCheckType", "CheckTypeId", "dbo.BD_CheckType");
            DropForeignKey("dbo.InstrumentCheckType", "InstrumentId", "dbo.BD_Instrument");
            DropForeignKey("dbo.BD_CheckType", "MeteorTypeId", "dbo.BD_MeteorType");
            DropForeignKey("dbo.BD_Instrument", "BD_CheckType_Id", "dbo.BD_CheckType");
            DropIndex("dbo.InstrumentMeteorType", new[] { "MeteorTypeId" });
            DropIndex("dbo.InstrumentMeteorType", new[] { "InstrumentId" });
            DropIndex("dbo.InstrumentCheckType", new[] { "CheckTypeId" });
            DropIndex("dbo.InstrumentCheckType", new[] { "InstrumentId" });
            DropIndex("dbo.SD_UserRole", new[] { "User_ID" });
            DropIndex("dbo.SD_UserRole", new[] { "Role_ID" });
            DropIndex("dbo.SD_User", new[] { "Role_ID" });
            DropIndex("dbo.SD_User", new[] { "UserId" });
            DropIndex("dbo.SD_UserLog", new[] { "User_ID" });
            DropIndex("dbo.SD_RoleFunction", new[] { "SD_Role_Id" });
            DropIndex("dbo.SD_RoleFunction", new[] { "SD_Function_Id" });
            DropIndex("dbo.BD_WindDirection", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Visibility", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Standard", new[] { "DeviceItem_Id" });
            DropIndex("dbo.BD_Standard", new[] { "Installation_ID" });
            DropIndex("dbo.BD_Site", new[] { "OrganizationUnit_ID" });
            DropIndex("dbo.BD_Remission", new[] { "Receive_ID" });
            DropIndex("dbo.BD_Randiation", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Rainfall", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_CalibrationResult", new[] { "TestDevice_ID" });
            DropIndex("dbo.BD_Back", new[] { "Receive_ID" });
            DropIndex("dbo.BD_Test", new[] { "MeteorType_ID" });
            DropIndex("dbo.BD_Test", new[] { "Installation_ID" });
            DropIndex("dbo.BD_Receive", new[] { "Unit_ID" });
            DropIndex("dbo.BD_ReceiveInstrument", new[] { "Receive_ID" });
            DropIndex("dbo.BD_ReceiveInstrument", new[] { "Instrument_ID" });
            DropIndex("dbo.BD_InstrumentTest", new[] { "UserId" });
            DropIndex("dbo.BD_InstrumentTest", new[] { "CheckType_ID" });
            DropIndex("dbo.BD_InstrumentTest", new[] { "Test_ID" });
            DropIndex("dbo.BD_InstrumentTest", new[] { "ReceiveInstrument_ID" });
            DropIndex("dbo.BD_CheckType", new[] { "MeteorTypeId" });
            DropIndex("dbo.BD_Instrument", new[] { "BD_CheckType_Id" });
            DropIndex("dbo.BD_TestItem", new[] { "Instrument_ID" });
            DropIndex("dbo.BD_TestItem", new[] { "InstrumentTest_ID" });
            DropIndex("dbo.BD_TestItem", new[] { "Test_ID" });
            DropIndex("dbo.BD_Appendix", new[] { "TestDevice_ID" });
            DropColumn("dbo.AbpUsers", "Memo");
            DropColumn("dbo.AbpUsers", "IsLeader");
            DropColumn("dbo.AbpUsers", "Sex");
            DropTable("dbo.InstrumentMeteorType");
            DropTable("dbo.InstrumentCheckType");
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
            DropTable("dbo.BD_WindDirection",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_WindDirection_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Wind",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Wind_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Visibility",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Visibility_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Standard",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Standard_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Site",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Site_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Rules",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Rules_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Remission",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Remission_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Randiation",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Randiation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Rainfall",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Rainfall_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_CalibrationResult",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_CalibrationResult_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Back",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Back_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Installation",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Installation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Test");
            DropTable("dbo.BD_Unit",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Unit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Receive",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Receive_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_ReceiveInstrument");
            DropTable("dbo.BD_InstrumentTest",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_InstrumentTest_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_MeteorType",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_MeteorType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_CheckType",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_CheckType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Instrument");
            DropTable("dbo.BD_TestItem",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_TestItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BD_Appendix",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BD_Appendix_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id", cascadeDelete: true);
        }
    }
}
