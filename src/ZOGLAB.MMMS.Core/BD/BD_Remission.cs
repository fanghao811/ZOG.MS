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
    [Table("BD_Remission")]
    public class BD_Remission : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	CertificateId_ID 收发登记ID  VARCHAR(20)
        [ForeignKey("Receive_ID")]
        public BD_ReceiveDevice Receive { get; set; }
        public long Receive_ID { get; set; }

        //3	UserName 返样者 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string UserName { get; set; }

        //4	strDateTime 返样时间    VARCHAR(20)
        public DateTime StrDateTime { get; set; }

        public bool IsDeleted { get; set; }
    }

}
