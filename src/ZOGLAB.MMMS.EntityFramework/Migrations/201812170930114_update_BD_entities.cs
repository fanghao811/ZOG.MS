namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_BD_entities : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BD_Back", name: "BD_Receive_ID", newName: "Receive_ID");
            RenameColumn(table: "dbo.BD_DeviceItem", name: "BD_ReceiveDeviceId", newName: "ReceiveDeviceId");
            RenameColumn(table: "dbo.BD_ReceiveDevice", name: "BD_Receive_ID", newName: "Receive_ID");
            RenameColumn(table: "dbo.BD_Test", name: "BD_Receive_ID", newName: "Receive_ID");
            RenameColumn(table: "dbo.BD_TestDevice", name: "TestId", newName: "Test_ID");
            RenameIndex(table: "dbo.BD_Back", name: "IX_BD_Receive_ID", newName: "IX_Receive_ID");
            RenameIndex(table: "dbo.BD_DeviceItem", name: "IX_BD_ReceiveDeviceId", newName: "IX_ReceiveDeviceId");
            RenameIndex(table: "dbo.BD_ReceiveDevice", name: "IX_BD_Receive_ID", newName: "IX_Receive_ID");
            RenameIndex(table: "dbo.BD_Test", name: "IX_BD_Receive_ID", newName: "IX_Receive_ID");
            RenameIndex(table: "dbo.BD_TestDevice", name: "IX_TestId", newName: "IX_Test_ID");
            AddColumn("dbo.BD_Receive", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BD_Receive", "CreatorUserId", c => c.Long());
            AddColumn("dbo.BD_DeviceItem", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BD_DeviceItem", "CreatorUserId", c => c.Long());
            AddColumn("dbo.BD_ReceiveDevice", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BD_ReceiveDevice", "CreatorUserId", c => c.Long());
            AddColumn("dbo.BD_TestDevice", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.BD_TestDevice", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BD_TestDevice", "CreatorUserId", c => c.Long());
            AlterColumn("dbo.BD_Instrument", "IsUsing", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BD_Instrument", "IsUsing", c => c.Int(nullable: false));
            DropColumn("dbo.BD_TestDevice", "CreatorUserId");
            DropColumn("dbo.BD_TestDevice", "CreationTime");
            DropColumn("dbo.BD_TestDevice", "IsDeleted");
            DropColumn("dbo.BD_ReceiveDevice", "CreatorUserId");
            DropColumn("dbo.BD_ReceiveDevice", "CreationTime");
            DropColumn("dbo.BD_DeviceItem", "CreatorUserId");
            DropColumn("dbo.BD_DeviceItem", "CreationTime");
            DropColumn("dbo.BD_Receive", "CreatorUserId");
            DropColumn("dbo.BD_Receive", "CreationTime");
            RenameIndex(table: "dbo.BD_TestDevice", name: "IX_Test_ID", newName: "IX_TestId");
            RenameIndex(table: "dbo.BD_Test", name: "IX_Receive_ID", newName: "IX_BD_Receive_ID");
            RenameIndex(table: "dbo.BD_ReceiveDevice", name: "IX_Receive_ID", newName: "IX_BD_Receive_ID");
            RenameIndex(table: "dbo.BD_DeviceItem", name: "IX_ReceiveDeviceId", newName: "IX_BD_ReceiveDeviceId");
            RenameIndex(table: "dbo.BD_Back", name: "IX_Receive_ID", newName: "IX_BD_Receive_ID");
            RenameColumn(table: "dbo.BD_TestDevice", name: "Test_ID", newName: "TestId");
            RenameColumn(table: "dbo.BD_Test", name: "Receive_ID", newName: "BD_Receive_ID");
            RenameColumn(table: "dbo.BD_ReceiveDevice", name: "Receive_ID", newName: "BD_Receive_ID");
            RenameColumn(table: "dbo.BD_DeviceItem", name: "ReceiveDeviceId", newName: "BD_ReceiveDeviceId");
            RenameColumn(table: "dbo.BD_Back", name: "Receive_ID", newName: "BD_Receive_ID");
        }
    }
}
