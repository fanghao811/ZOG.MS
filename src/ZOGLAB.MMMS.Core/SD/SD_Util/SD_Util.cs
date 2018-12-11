using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 11,共用信息配置表(SD_Utils)
    /// </summary>
    [Table("SD_Util")]
    public class SD_Util : Entity<long>, IHasCreationTime
    {
        public const int MaxLength_10 = 10;
        public const int MaxLength_50 = 50;
        public const int MaxLength_200 = 200;

        //1.数据表编码
        [MaxLength(MaxLength_50)]
        public string TableCode{ get; set; }

        //2.编码列
        [MaxLength(MaxLength_50)]
        public string TableColumn { get; set; }

        //3.配置项编码名称
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //4.编码前缀
        [MaxLength(MaxLength_10)]
        public string Prefix { get; set; }

        //5.编码位数
        public int Length { get; set; }

        //6.编码序号
        public int KeyIndex { get; set; }

        //7.关键字编码
        [MaxLength(MaxLength_50)]
        public string KeyValue { get; set; }

        //8.说明
        [MaxLength(MaxLength_200)]
        public string Description { get; set; }

        //9.备注
        [MaxLength(MaxLength_200)]
        public string Memo { get; set; }

        //10.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_Util()
        {
            CreationTime = DateTime.Now;
        }
    }
}
