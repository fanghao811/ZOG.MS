using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 12，标准器信息表（BD_Standard）
    /// </summary>
    [Table("BD_TestItem")]
    public class BD_TestItem : CreationAuditedEntity<long>,ISoftDelete
    {
        public const int MaxLength_50 = 50;
        public const int MaxLength_20 = 20;

        //1.检定单ID
        [ForeignKey("Test_ID")]
        public BD_Test Test { get; set; }
        public long Test_ID { get; set; }

        //2.设备检测项目从表ID   
        [ForeignKey("InstrumentTest_ID")]
        public BD_InstrumentTest InstrumentTest { get; set; }
        public long InstrumentTest_ID { get; set; }

        //3.被检仪器基本信息表ID
        [ForeignKey("Instrument_ID")]
        public BD_Instrument Instrument { get; set; }
        public long? Instrument_ID { get; set; }

        //4.仪器交接状态
        [MaxLength(MaxLength_50)]
        public string Check_User { get; set; }

        //5.检测时间
        public DateTime Check_DateTime { get; set; }

        //6.检测结果
        [MaxLength(MaxLength_50)]
        public string Check_Result { get; set; }

        //7.检测不合格原因
        [MaxLength(MaxLength_50)]
        public string Check_NGMark { get; set; }

        //8.外观检查
        [MaxLength(MaxLength_20)]
        public string Appearance { get; set; }

        //9.环境温度
        public decimal EnvirTemp { get; set; }

        //10.环境湿度
        public decimal EnvirHumidity { get; set; }

        //11.环境气压
        public decimal EnvirPressure { get; set; }

        //12.审核状态
        public bool ForCheck { get; set; }

        //13.审核日期
        public DateTime ForCheck_DateTime { get; set; }

        //14.审核者
        [MaxLength(MaxLength_20)]
        public string ForCheck_User { get; set; }

        //15.审核结果
        [MaxLength(MaxLength_20)]
        public string ForCheck_Result { get; set; }

        //16.审核不合格原因
        [MaxLength(MaxLength_50)]
        public string ForCheck_NGMark { get; set; }

        //17.批准状态
        public bool ForApprove { get; set; }

        //18.批准者
        [MaxLength(MaxLength_20)]
        public string ForApprove_User { get; set; }

        //19.批准日期
        public DateTime ForApprove_DateTime { get; set; }

        //20.批准结果
        [MaxLength(MaxLength_20)]
        public string ForApprove_Result { get; set; }

        //21.批准不合格原因
        [MaxLength(MaxLength_20)]
        public string ForApprove_NGMark { get; set; }

        //22.证书号
        [MaxLength(MaxLength_50)]
        public string CertificateId { get; set; }

        //23.原始记录号
        [MaxLength(MaxLength_50)]
        public string RawRecordsetId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
