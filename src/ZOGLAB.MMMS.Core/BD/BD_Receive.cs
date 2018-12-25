using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 3,收发单主表（BD_Receive）
    /// </summary>
    [Table("BD_Receive")]
    public class BD_Receive : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.送检单位ID   foreignKey site
        [ForeignKey("Unit_ID ")]
        public BD_Unit Unit { get; set; }
        public long? Unit_ID { get; set; }

        //2.收发单号
        [MaxLength(MaxLength_50)]
        public string Number { get; set; }

        //3.设备数量
        public int? Device_Num { get; set; }

        //2.客户地址
        [MaxLength(MaxLength_50)]
        public string Address { get; set; }

        //2.联系人
        [MaxLength(MaxLength_50)]
        public string Contact { get; set; }

        //2.联系方式
        [MaxLength(MaxLength_20)]
        public string ContactTel { get; set; }

        //6.送检快递单号
        [MaxLength(MaxLength_50)]
        public string ExpressDelivery { get; set; }

        //7.送检方式
        public ReceiveModel Model { get; set; }

        //8.收发从表
        public ICollection<BD_ReceiveInstrument> ReceiveInstruments { get; set; }

        //9.是否有效
        public bool IsDeleted { get; set; }

        public enum ReceiveModel
        {
            邮寄 = 0,
            上门 = 1
        }
    }
}
