using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 14,风向检测数据表（BD_WindDirection）
    /// </summary>
    [Table("BD_WindDirection")]
    public class BD_WindDirection : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.TestDevice_ID INT
        [ForeignKey("TestDevice_ID")]
        public BD_TestItem TestDevice { get; set; }
        public long TestDevice_ID { get; set; }

        //2.IntDataID 读数序号    INT
        public int IntDataID { get; set; }

        //3.StandVal    标准器示值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StandVal { get; set; }

        //4.StandRevisedVal 标准器修正值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StandRevisedVal { get; set; }

        //5.StandReal 标准器修正后值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StandReal { get; set; }

        //6.ViewVal 被检示值    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string ViewVal { get; set; }

        //7.DiffPressVal 误差值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string DiffPressVal { get; set; }

        //8.CalibrationPointVal 检测点 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string CalibrationPointVal { get; set; }

        //9.StrViewVal 启动风速示值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StrViewVal { get; set; }

        //10.StrStandVal 启动风速标准值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StrStandVal { get; set; }

        //11.StrKVal 回归方程K值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StrKVal { get; set; }

        //12.StrbVal 回归方程b值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StrbVal { get; set; }

        //13.EnvirTempVal1 起始环境温度  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string EnvirTempVal1 { get; set; }

        //14.EnvirTempVal2 结束环境温度  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string EnvirTempVal2 { get; set; }

        //15.EnvirHumVal1 起始环境湿度  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string EnvirHumVal1 { get; set; }

        //16.EnvirHumVal2 结束环境湿度  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string EnvirHumVal2 { get; set; }

        //17.EnvirPressVal1 起始环境气压  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string EnvirPressVal1 { get; set; }

        //18.EnvirPressVal2 结束环境气压  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string EnvirPressVal2 { get; set; }

        //19.IntType 数据类型    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string IntType { get; set; }

        //20.IntCaliPointIndex 检测点序号   INT
        public int IntCaliPointIndex { get; set; }

        //21.StrDateTime 检测时间 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StrDateTime { get; set; }

        //22.CheckType 检测类型    INT
        public int CheckType { get; set; }

        //23.Types   数据采集方式 INT
        public int Types { get; set; }

        //IsActive 是否有效    INT
        public bool IsDeleted { get; set; }
    }

}
