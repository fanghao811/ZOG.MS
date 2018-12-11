using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 共用信息配置表(SD_Utils)
    /// </summary>
    [Table("SD_Role")]
    public class SD_Role : Entity<long>, IHasCreationTime
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_100 = 100;
 
        //1.角色编码
        [MaxLength(MaxLength_20)]
        public string Code { get; set; }

        //2.角色名称
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //3.是否为超级用户
        public bool IsAdmin { get; set; }

        //4.角色描述
        [MaxLength(MaxLength_100)]
        public string Description { get; set; }

        //5.备注
        [MaxLength(MaxLength_100)]
        public string Memo { get; set; }

        //10.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_Role()
        {
            CreationTime = DateTime.Now;
        }
    }
}
