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
    [Table("BD_CalibrationType")]
    public class BD_CalibrationType : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	CheckName 检测类型    VARCHAR(20)
        public string BackNumber { get; set; }

        //3	Mark 备注  VARCHAR(50)
        public string Mark { get; set; }
 
        public bool IsDeleted { get; set; }
    }

}
