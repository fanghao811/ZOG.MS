using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    ///13,温湿压检测数据表（BD_CalibrationResult）
    /// </summary>
    [Table("BD_CalibrationResult")]
    public class BD_CalibrationResult : CreationAuditedEntity<long>,ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.检测单信息主表ID 
        [ForeignKey("TestDevice_ID")]
        public BD_TestItem BD_TestDevice { get; set; }
        public long TestDevice_ID { get; set; }

        //2.读数序号
        public int IntDataID { get; set; }

        //3.标准器示值
        [MaxLength(MaxLength_20)]
        public string StandVal { get; set; }

        //4.标准器修正值
        [MaxLength(MaxLength_20)]
        public string StandRevisedVal { get; set; }

        //5.标准器修正后值
        [MaxLength(MaxLength_20)]
        public string StandReal { get; set; }

        //6.被检示值
        [MaxLength(MaxLength_20)]
        public string ViewVal { get; set; }

        //7.误差值
        [MaxLength(MaxLength_20)]
        public string DiffPressVal { get; set; }

        //8.检测点
        [MaxLength(MaxLength_20)]
        public string CalibrationPointVal { get; set; }

        //9.数据类型
        [MaxLength(MaxLength_20)]
        public string IntType { get; set; }

        //10.检测点序号
        public int IntCaliPointIndex { get; set; }

        //11.检测时间
        public DateTime StrDateTime { get; set; }

        //12.检测类型
        public bool CheckType { get; set; }

        //13.检测要素类型
        public Checkflag CheckFlag { get; set; }

        //14.数据采集方式
        public bool Types { get; set; }

        public bool IsDeleted { get; set; }

        public enum Checkflag
        {
            温度=0,
            湿度=1,
            气压=2
        }
    }
}
