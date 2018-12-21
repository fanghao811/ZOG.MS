using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Abp.Zero.EntityFramework;
using ZOGLAB.MMMS.Authorization.Roles;
using ZOGLAB.MMMS.Authorization.Users;
using ZOGLAB.MMMS.BD;
using ZOGLAB.MMMS.Chat;
using ZOGLAB.MMMS.Friendships;
using ZOGLAB.MMMS.MultiTenancy;
using ZOGLAB.MMMS.SD;
using ZOGLAB.MMMS.Storage;

namespace ZOGLAB.MMMS.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */

    public class MMMSDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        /* 新增SD系统实体 2018/12/06  */
        public virtual IDbSet<SD_Organization> SD_Organizations { get; set; }
        public virtual IDbSet<SD_User> SD_Users { get; set; }
        public virtual IDbSet<SD_Role> SD_Roles { get; set; }
        public virtual IDbSet<SD_Function> SD_Functions { get; set; }
        public virtual IDbSet<SD_RoleFunction> SD_RoleFunction { get; set; }
        public virtual IDbSet<SD_UserRole> SD_UserRole { get; set; }
        public virtual IDbSet<SD_Parameter> SD_Parameters { get; set; }
        public virtual IDbSet<SD_UserLog> SD_UserLogs { get; set; }
        public virtual IDbSet<SD_UIModel> SD_UIModels { get; set; }
        public virtual IDbSet<SD_Report> SD_Reports { get; set; }
        public virtual IDbSet<SD_Util> SD_Util { get; set; }
        public virtual IDbSet<SD_System> SD_System { get; set; }
        public virtual IDbSet<TreeUnit> TreeUnits { get; set; }
        public virtual IDbSet<SD_MenuTreeUnit> SD_MenuTreeUnits { get; set; }

        /* 新增BD系统实体 2018/12/17  */
        public virtual IDbSet<BD_Instrument> BD_Instruments { get; set; }
        public virtual IDbSet<BD_EssentialFactor> BD_EssentialFactors { get; set; }
        public virtual IDbSet<BD_Receive> BD_Receives { get; set; }
        public virtual IDbSet<BD_Back> BD_Backs { get; set; }
        public virtual IDbSet<BD_ReceiveDevice> BD_ReceiveDevices { get; set; }

        /* PartII */
        public virtual IDbSet<BD_DeviceItem> BD_DeviceItems { get; set; }
        public virtual IDbSet<BD_Unit> BD_Units { get; set; }
        public virtual IDbSet<BD_TestDevice> BD_TestDevices { get; set; }
        public virtual IDbSet<BD_Test> BD_Tests { get; set; }
        public virtual IDbSet<BD_Rules> BD_Rules { get; set; }
        public virtual IDbSet<BD_Installation> BD_Installations { get; set; }
        public virtual IDbSet<BD_Standard> BD_Standards { get; set; }
        public virtual IDbSet<BD_CalibrationResult> BD_CalibrationResults { get; set; }

        /* 14- 22 */
        public virtual IDbSet<BD_Wind> BD_Wind { get; set; }
        public virtual IDbSet<BD_WindDirection> BD_WindDirection { get; set; }
        public virtual IDbSet<BD_Rainfall> BD_Rainfall { get; set; }
        public virtual IDbSet<BD_Randiation> BD_Randiation { get; set; }
        public virtual IDbSet<BD_Visibility> BD_Visibility { get; set; }

        public virtual IDbSet<BD_Appendix> BD_Appendix { get; set; }
        public virtual IDbSet<BD_Site> BD_Site { get; set; }
        public virtual IDbSet<BD_Remission> BD_Remission { get; set; }
        public virtual IDbSet<BD_MeteorType> BD_MeteorType { get; set; }
        public virtual IDbSet<BD_CheckType> BD_CheckType { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //    //    modelBuilder.Entity<BD_DeviceItem>().HasOptional<BD_Test>(r => r.BD_Test).WithMany().WillCascadeOnDelete(false);
        //    //    modelBuilder.Entity<BD_DeviceItem>().HasOptional<BD_ReceiveDevice>(r => r.BD_ReceiveDevice).WithMany().WillCascadeOnDelete(false);
        //}


        public MMMSDbContext()
            : base("Default")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MMMSDbContext>());
        }

        public MMMSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public MMMSDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public MMMSDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
