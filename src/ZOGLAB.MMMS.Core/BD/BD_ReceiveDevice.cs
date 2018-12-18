using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 5，收发设备从表（BD_ReceiveDevice）
    /// </summary>
    [Table("BD_ReceiveDevice")]
    public class BD_ReceiveDevice : CreationAuditedEntity<long>,ISoftDelete
    {
        public const int MaxLength_50 = 50;

        //1.收发单号ID   foreignKey
        [ForeignKey("ReceiveDevice_ID")]
        public BD_ReceiveDevice ReceiveDevice { get; set; }
        public long ReceiveDevice_ID { get; set; }

        //2.被检仪器ID   foreignKey
        [ForeignKey("Instrument_ID")]
        public BD_Instrument Instrument { get; set; }
        public long Instrument_ID { get; set; }

        //3.客户需求
        [MaxLength(MaxLength_50)]
        public string UnitMark { get; set; }

        //4.返样单ID
        public int Back_ID { get; set; }

        //5.备注
        [MaxLength(MaxLength_50)]
        public string Mark { get; set; }

        //6.是否有效
        public bool IsDeleted { get; set; }

    }
}
