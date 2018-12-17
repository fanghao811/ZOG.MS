using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 4,返样信息表（BD_Back）
    /// </summary>
    [Table("BD_Test")]
    public class BD_Test : AuditedEntity<long>
    {
        public const int MaxLength_50 = 50;

        //1.收发单号ID
        [ForeignKey("BD_Receive_ID")]
        public BD_Receive BD_Receive { get; set; }
        public long BD_Receive_ID { get; set; }

        //2.检测单号
        [MaxLength(MaxLength_50)]
        public string Check_Num { get; set; }

        //3.检测要素
        [MaxLength(MaxLength_50)]
        public string Check_Type { get; set; }

        //4.检测开始时间
        public DateTime StartDate { get; set; }

        //5.结束时间
        public DateTime FinishDate { get; set; }

        //6.站点ID
        public int Site_ID { get; set; }

        //7.业务类型
        public VMType VocationalWorkType { get; set; }

        //8.备注
        public string Mark { get; set; }
   
        public enum VMType {
            实验室检定=0,
            实验室校准=1,
            现场校准=2,
            现场核查=3
        }
    }
}
