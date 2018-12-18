using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 18，检定/校准/核查/原始数据附件信息表（BD_Appendix）
    /// </summary>
    [Table("BD_ASeed")]
    public class BD_ASeed : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2.返样数量
        public int BackNumber { get; set; }

        //3.接收者
        [MaxLength(MaxLength_50)]
        public string Users { get; set; }

        public bool IsDeleted { get; set; }
    }

}
