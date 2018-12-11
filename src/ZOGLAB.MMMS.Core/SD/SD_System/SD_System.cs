using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 12,系统配置信息表(SD_System)
    /// </summary>
    [Table("SD_System")]
    public class SD_System :Entity<long>, IHasCreationTime
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_200 = 200;

        //1.系统编码
        [MaxLength(MaxLength_50)]
        public string Code{ get; set; }

        //2.系统名
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //3.登录链接
        [MaxLength(MaxLength_50)]
        public string Url { get; set; }

        //4.数据名
        [MaxLength(MaxLength_20)]
        public string DatabaseName { get; set; }

        //5.当前用户名
        [MaxLength(MaxLength_50)]
        public string UserName  { get; set; }

        //6.当前用户口令
        [MaxLength(MaxLength_50)]
        public string UserPwd { get; set; }

        //7.是否显示
        public bool IsShow { get; set; }

        //8.备注
        [MaxLength(MaxLength_200)]
        public string Memo { get; set; }

        //9.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_System()
        {
            CreationTime = DateTime.Now;
        }
    }
}
