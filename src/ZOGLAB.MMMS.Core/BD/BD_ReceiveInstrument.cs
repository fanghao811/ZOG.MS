using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 5，收发设备从表（BD_ReceiveDevice）
    /// </summary>
    [Table("BD_ReceiveInstrument")]
    public class BD_ReceiveInstrument : AuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_50 = 50;

        //1.被检仪器ID   foreignKey
        [ForeignKey("Instrument_ID")]
        public BD_Instrument Instrument { get; set; }
        public long Instrument_ID { get; set; }

        //2.收发单号ID   foreignKey
        [ForeignKey("Receive_ID")]
        [InverseProperty("ReceiveInstruments")]
        public BD_Receive Receive { get; set; }
        public long Receive_ID { get; set; }

        //3.客户需求
        [MaxLength(MaxLength_50)]
        public string UnitMark { get; set; }

        //4.返样单ID
        public long? Back_ID { get; set; }

        public BD_ReceiveInstrument() { }

        public bool IsDeleted { get; set; }

        public BD_ReceiveInstrument(long instrumentId, long receiveId)
        {
            Instrument_ID = instrumentId;
            Receive_ID = receiveId;
        }

    }
}
