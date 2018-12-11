using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 9,系统UI模型表(SD_UIModel)
    /// </summary>
    [Table("SD_UIModel")]
    public class SD_UIModel : Entity<long>, IHasCreationTime
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_200 = 200;

        //1.页面名称编码（含路径）
        [MaxLength(MaxLength_200)]
        public string PageCode { get; set; }

        //2.实体名称编码（含路径）
        [MaxLength(MaxLength_200)]
        public string EntityCode { get; set; }

        //3.内部编码
        [MaxLength(MaxLength_50)]
        public string Code { get; set; }

        //4.展示名称
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //5.数据类型
        public DataType DataType { get; set; }

        //6.所在电脑设备名称
        public string OperateDevice { get; set; }

        //7.电脑IP
        [MaxLength(MaxLength_20)]
        public string OperateIP { get; set; }

        //8.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_UIModel()
        {
            CreationTime = DateTime.Now;
        }
    }

    public enum DataType
    {
        BOOL = 1,
        INT64 = 2,
        INT = 3,
        STRING = 4,
        DATETIME = 5,
        DECIMAL = 6,
        FLOAT = 7
    };
}
