using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 5,权限分配表(SD_RoleFunction)
    /// </summary>
    [Table("SD_RoleFunction")]
    public class SD_RoleFunction : Entity<long>, IHasCreationTime
    {
        //1.角色
        public long Role_ID { get; set; }
        public SD_Role SD_Role { get; set; }

        //2.功能
        public long Function_ID { get; set; }
        public SD_Function SD_Function { get; set; }

        //3.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_RoleFunction()
        {
            CreationTime = DateTime.Now;
        }
    }
}
