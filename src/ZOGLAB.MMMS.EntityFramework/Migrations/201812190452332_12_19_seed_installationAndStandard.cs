namespace ZOGLAB.MMMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12_19_seed_installationAndStandard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BD_ReceiveDevice", "ReceiveDevice_ID", "dbo.BD_ReceiveDevice");
            DropForeignKey("dbo.BD_Test", "Installation_ID", "dbo.BD_Installation");
            DropIndex("dbo.BD_ReceiveDevice", new[] { "ReceiveDevice_ID" });
            DropIndex("dbo.BD_Test", new[] { "Installation_ID" });
            RenameColumn(table: "dbo.BD_DeviceItem", name: "BD_ReceiveDevice_Id", newName: "ReceiveDevice_Id");
            RenameColumn(table: "dbo.BD_DeviceItem", name: "BD_Test_Id", newName: "Test_ID");
            RenameIndex(table: "dbo.BD_DeviceItem", name: "IX_BD_Test_Id", newName: "IX_Test_ID");
            RenameIndex(table: "dbo.BD_DeviceItem", name: "IX_BD_ReceiveDevice_Id", newName: "IX_ReceiveDevice_Id");
            AddColumn("dbo.BD_ReceiveDevice", "Receive_ID", c => c.Long(nullable: false));
            AddColumn("dbo.BD_Test", "Receive_ID", c => c.Long(nullable: false));
            AddColumn("dbo.AbpUsers", "Sex", c => c.String(maxLength: 20));
            AddColumn("dbo.AbpUsers", "IsLeader", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "Memo", c => c.String(maxLength: 100));
            AddColumn("dbo.BD_Standard", "DeviceItem_Id", c => c.Long());
            AlterColumn("dbo.BD_ReceiveDevice", "Back_ID", c => c.Long(nullable: false));
            CreateIndex("dbo.BD_ReceiveDevice", "Receive_ID");
            CreateIndex("dbo.BD_Test", "Receive_ID");
            CreateIndex("dbo.BD_Standard", "DeviceItem_Id");
            AddForeignKey("dbo.BD_ReceiveDevice", "Receive_ID", "dbo.BD_Receive", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BD_Test", "Receive_ID", "dbo.BD_Receive", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BD_Standard", "DeviceItem_Id", "dbo.BD_DeviceItem", "Id");
            DropColumn("dbo.BD_ReceiveDevice", "ReceiveDevice_ID");
            DropColumn("dbo.BD_Test", "Installation_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BD_Test", "Installation_ID", c => c.Long(nullable: false));
            AddColumn("dbo.BD_ReceiveDevice", "ReceiveDevice_ID", c => c.Long(nullable: false));
            DropForeignKey("dbo.BD_Standard", "DeviceItem_Id", "dbo.BD_DeviceItem");
            DropForeignKey("dbo.BD_Test", "Receive_ID", "dbo.BD_Receive");
            DropForeignKey("dbo.BD_ReceiveDevice", "Receive_ID", "dbo.BD_Receive");
            DropIndex("dbo.BD_Standard", new[] { "DeviceItem_Id" });
            DropIndex("dbo.BD_Test", new[] { "Receive_ID" });
            DropIndex("dbo.BD_ReceiveDevice", new[] { "Receive_ID" });
            AlterColumn("dbo.BD_ReceiveDevice", "Back_ID", c => c.Int(nullable: false));
            DropColumn("dbo.BD_Standard", "DeviceItem_Id");
            DropColumn("dbo.AbpUsers", "Memo");
            DropColumn("dbo.AbpUsers", "IsLeader");
            DropColumn("dbo.AbpUsers", "Sex");
            DropColumn("dbo.BD_Test", "Receive_ID");
            DropColumn("dbo.BD_ReceiveDevice", "Receive_ID");
            RenameIndex(table: "dbo.BD_DeviceItem", name: "IX_ReceiveDevice_Id", newName: "IX_BD_ReceiveDevice_Id");
            RenameIndex(table: "dbo.BD_DeviceItem", name: "IX_Test_ID", newName: "IX_BD_Test_Id");
            RenameColumn(table: "dbo.BD_DeviceItem", name: "Test_ID", newName: "BD_Test_Id");
            RenameColumn(table: "dbo.BD_DeviceItem", name: "ReceiveDevice_Id", newName: "BD_ReceiveDevice_Id");
            CreateIndex("dbo.BD_Test", "Installation_ID");
            CreateIndex("dbo.BD_ReceiveDevice", "ReceiveDevice_ID");
            AddForeignKey("dbo.BD_Test", "Installation_ID", "dbo.BD_Installation", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BD_ReceiveDevice", "ReceiveDevice_ID", "dbo.BD_ReceiveDevice", "Id");
        }
    }
}
