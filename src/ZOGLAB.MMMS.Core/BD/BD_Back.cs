using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 4,������Ϣ��BD_Back��
    /// </summary>
    [Table("BD_Back")]
    public class BD_Back : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_50 = 50;

        //1.�շ�����ID   foreignKey
        [ForeignKey("Receive_ID")]
        public BD_ReceiveDevice Receive { get; set; }
        public long Receive_ID { get; set; }

        //2.��������
        public int BackNumber { get; set; }

        //3.������
        [MaxLength(MaxLength_50)]
        public string Users { get; set; }

        //4.��������ϵ�绰
        public string Tel { get; set; }

        //5.����ʱ��
        public DateTime RegisterDate { get; set; }

        //6.������ݵ���
        [MaxLength(MaxLength_50)]
        public string ExpressDelivery { get; set; }

        //7.������ʽ
        public bool BackModel { get; set; }

        public bool IsDeleted { get; set; }

    }
}