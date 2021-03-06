using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 4,返样信息表（BD_Back）
    /// </summary>
    [Table("BD_Back")]
    public class BD_Back : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_50 = 50;

        //1.收发单号ID   foreignKey
        [ForeignKey("Receive_ID")]
        public BD_Receive Receive { get; set; }
        public long Receive_ID { get; set; }

        //2.返样数量
        public int BackNumber { get; set; }

        //3.接收者
        [MaxLength(MaxLength_50)]
        public string Users { get; set; }

        //4.接收者联系电话
        public string Tel { get; set; }

        //5.接收时间
        public DateTime RegisterDate { get; set; }

        //6.返样快递单号
        [MaxLength(MaxLength_50)]
        public string ExpressDelivery { get; set; }

        //7.返样方式
        public bool BackModel { get; set; }

        public bool IsDeleted { get; set; }

    }
}