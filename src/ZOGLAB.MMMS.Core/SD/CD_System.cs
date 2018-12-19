using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 1，系统参数表（CD_System）
    /// </summary>
    [Table("CD_System")]
    public class CD_System : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	Signal_Type 被检设备信号类型    INT
        public int Signal_Type { get; set; }

        //3	Data_IP 数据库IP   VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Data_IP { get; set; }

        //4	Data_Name 数据库名称   VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Data_Name { get; set; }

        //5	User_Name 用户名称    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string User_Name { get; set; }

        //6	User_password 登录密码    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string User_password { get; set; }

        //7	becausef_Type 是否基于业务平台    INT
        public int becausef_Type { get; set; }

        public bool IsDeleted { get; set; }
    }

}
