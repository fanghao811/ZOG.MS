using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 14，风速检测数据表（BD_Wind）
    /// </summary>
    [Table("BD_Wind")]
    public class BD_Wind: CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.检测单设备从表ID
        public int TestDevice_ID { get; set; }

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

        //9.启动风速示值
        [MaxLength(MaxLength_20)]
        public string StrViewVal { get; set; }

        //10.启动风速标准值
        [MaxLength(MaxLength_20)]
        public string StrStandVal { get; set; }

        //11.StrKVal 回归方程K值  
        [MaxLength(MaxLength_20)]
        public string StrKVal { get; set; }

        //12.StrbVal 回归方程b值  
        [MaxLength(MaxLength_20)]
        public string StrbVal { get; set; }

        //12.EnvirTempVal1 起始环境温度  
        [MaxLength(MaxLength_20)]
        public string EnvirTempVal1 { get; set; }

        //13EnvirTempVal2 结束环境温度  
        [MaxLength(MaxLength_20)]
        public string EnvirTempVal2 { get; set; }

        //14.EnvirHumVal1 起始环境湿度  
        [MaxLength(MaxLength_20)]
        public string EnvirHumVal1 { get; set; }

        //15.EnvirHumVal2 结束环境湿度  
        [MaxLength(MaxLength_20)]
        public string EnvirHumVal2 { get; set; }

        //16.EnvirPressVal1 起始环境气压  
        [MaxLength(MaxLength_20)]
        public string EnvirPressVal1 { get; set; }

        //17.EnvirPressVal2 结束环境气压  
        [MaxLength(MaxLength_20)]
        public string EnvirPressVal2 { get; set; }

        //18.DiffPressVal1 启动风速微压差计示值1 
        [MaxLength(MaxLength_20)]
        public string DiffPressVal1 { get; set; }

        //19.DiffPressVal2 启动风速微压差计示值2 
        [MaxLength(MaxLength_20)]
        public string DiffPressVal2 { get; set; }

        //20.IntType 数据类型    
        [MaxLength(MaxLength_20)]
        public string IntType { get; set; }

        //21.IntCaliPointIndex 检测点序号   
        public int IntCaliPointIndex { get; set; }

        //22.StrDateTime 检测时间 
        [MaxLength(MaxLength_20)]
        public string StrDateTime { get; set; }

        //23.CheckType 检测类型    
        public int CheckType { get; set; }

        //24.Types   数据采集方式 
        public int Types { get; set; }

        public bool IsDeleted { get; set; }
}
}


