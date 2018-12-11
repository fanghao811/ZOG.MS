using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZOGLAB.MMMS.Authorization.Users;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 共用信息配置表(SD_Utils)
    /// </summary>
    [Table("SD_User")]
    public class SD_User :Entity<long>,IHasCreationTime
    {
        public const int MaxLength_10 = 10;
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_100 = 100;
        public const int MaxLength_200 = 200;

        //TODO: 外键实现
        //用户ID
        [ForeignKey("UserId")]
        public User User { get; set; }
        public virtual long? UserId { get; set; }
        //TODO: 外键实现
        //角色ID

        [ForeignKey("Role_ID")]
        public SD_Role SD_Role { get; set; }
        public virtual long? Role_ID { get; set; }

        //1.用户编码
        [MaxLength(MaxLength_20)]
        public string Code { get; set; }

        //2.用户名称
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //3.组织结构ID
        public long Org_ID { get; set; }

        //4.性别
        [MaxLength(MaxLength_10)]
        public string Sex { get; set; }

        //5.所在部门
        [MaxLength(MaxLength_100)]
        public string DepartName { get; set; }

        //6.登录口令
        [MaxLength(MaxLength_50)]
        public string Pwd { get; set; }

        //8.联系电话
        [MaxLength(MaxLength_20)]
        public string Tel { get; set; }

        //9.是否领导
        public bool IsLeader { get; set; }

        //10.备注信息
        [MaxLength(MaxLength_100)]
        public string Memo { get; set; }

        //9.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_User()
        {
            CreationTime = DateTime.Now;
        }
    }
}
