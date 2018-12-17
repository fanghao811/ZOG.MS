using System.Data.Common;
using System.Data.Entity;
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


        public MMMSDbContext()
            : base("Default")
        {
            
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
