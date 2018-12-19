using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 3，规程信息表（SD_DirectiveRules）
    /// </summary>
    [Table("SD_DirectiveRules")]
    public class SD_DirectiveRules : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	Name 规程名称    VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //3	CheckNum 检定点 VARCHAR(500)
        [MaxLength(MaxLength_50)]
        public string CheckNum { get; set; }

        //4	Flag 启用状态    INT	
        public int Flag { get; set; }

        //5	Check_Type 规程类型    INT
        public int Check_Type { get; set; }

        public bool IsDeleted { get; set; }
    }

}
