using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 6,用户角色分配表(SD_UserRole)
    /// </summary>
    [Table("SD_UserRole")]
    public class SD_UserRole : Entity<long>, IHasCreationTime
    {
        //1.角色
        public long Role_ID { get; set; }
        [ForeignKey("Role_ID")]
        public SD_Role SD_Role { get; set; }

        //2.功能
        public long User_ID { get; set; }
        [ForeignKey("User_ID")]
        public SD_User SD_User { get; set; }

        //3.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_UserRole()
        {
            CreationTime = DateTime.Now;
        }
    }
}
