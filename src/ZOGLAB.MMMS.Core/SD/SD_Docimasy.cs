using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 4，检测信息表（SD_Docimasy）
    /// </summary>
    [Table("SD_Docimasy")]
    public class SD_Docimasy : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	DirectiveRules_ID 规程信息表ID INT
        public int DirectiveRules_ID { get; set; }

        //3	Number 检定序号    INT
        public int Number { get; set; }

        //4	CheckNum 检定点 decimal (3,1)
        public decimal CheckNum { get; set; }

        //5	Flag 读数次数    INT
        public int ReadTimes { get; set; }

        //6	CreateDate 稳定时间    INT
        public int StableTime { get; set; }

        //7	Stabilize 稳定条件    decimal (3, 1)
        public decimal Stabilize { get; set; }

        //8	ShiftingValue 偏移量 decimal (3, 1)
        public decimal ShiftingValue { get; set; }

        //9	CreateDate 操作时间    DateTime
        public DateTime CreateDate { get; set; }

        //10	Flag 是否启用    INT
        public int Flag { get; set; }

        public bool IsDeleted { get; set; }
    }

}
