using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 2,要素信息表（BD_EssentialFactor）
    /// </summary>
    [Table("BD_EssentialFactor")]
    public class BD_EssentialFactor : AuditedEntity<long>
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.仪器ID   foreignKey site
        [ForeignKey("Instrument_ID")]
        public BD_Instrument Instrument { get; set; }
        public long Instrument_ID { get; set; }

        //2.检测要素
        [MaxLength(MaxLength_20)]
        public string Name { get; set; }

        //3.要素类型
        public FactorModel Model { get; set; }


        //构造函数
        public BD_EssentialFactor()
        {
            CreationTime = DateTime.Now;
        }

        public enum FactorModel
        {
            温度 = 0,
            湿度 = 1,
            气压 = 2,
            风速 = 3,
            风向 = 4,
            雨量 = 5,
            辐射 = 6,
            能见度 = 7
        }
    }
}
