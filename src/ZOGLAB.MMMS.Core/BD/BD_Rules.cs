using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 9，送检单位信息表（BD_Unit）
    /// </summary>
    [Table("BD_Rules")]
    public class BD_Rules : Entity<long>,ICreationAudited,ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.规程编号 
        [MaxLength(MaxLength_20)]
        public string RuleId { get; set; }

        //2.规程名称
        [MaxLength(MaxLength_20)]
        public string Address { get; set; }

        //3.发布日期        
        public DateTime StrDateTime { get; set; }

        //4.作业指导书
        [MaxLength(MaxLength_50)]
        public string StrJobDoc { get; set; }

        //5.文件路径
        [MaxLength(MaxLength_50)]
        public string FilePath { get; set; }

        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
