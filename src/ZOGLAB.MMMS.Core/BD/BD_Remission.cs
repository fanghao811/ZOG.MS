using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 20，仪器返样信息表（BD_Remission）
    /// </summary>
    [Table("BD_Remission")]
    public class BD_Remission : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2.BD_Receive.ID收发登记表ID关联
        [ForeignKey("Receive_ID")]
        public BD_Receive Receive { get; set; }
        public long Receive_ID { get; set; }

        //3	UserName 返样者 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string UserName { get; set; }

        //4	strDateTime 返样时间    VARCHAR(20)
        public DateTime StrDateTime { get; set; }

        public bool IsDeleted { get; set; }
    }

}
