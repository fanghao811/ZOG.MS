using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ZOGLAB.MMMS.BD
{
    [AutoMapFrom(typeof(BD_InstrumentTest))]
    public class InstrumentTestEditDto
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.收发单从表ID
        public string ReceiveInstrument { get; set; }
        public long? ReceiveInstrument_ID { get; set; }

        //2.检测单表ID
        public long? Test_ID { get; set; }

        //2.1 检测项目ID
        public string CheckType { get; set; }
        public long? CheckType_ID { get; set; }

        //3.仪器交接状态
        public bool IntHandover { get; set; }

        //4.仪器接收者ID
        public string User { get; set; }
        public long? UserId { get; set; }

        //5.仪器挑选状态
        public bool Calibration { get; set; }

        //6.仪器检测状态
        public bool CheckFlag { get; set; }

        //7.返样方式
        public bool IsFinished { get; set; }

        //8.重检状态
        public bool IntReCaliFlag { get; set; }

        //9.物质编码
        [MaxLength(MaxLength_50)]
        public string Number { get; set; }

        //10.有效日期
        [MaxLength(MaxLength_20)]
        public string CaliValidateDate { get; set; }

        //11.不确定度
        [MaxLength(MaxLength_20)]
        public string CaliU { get; set; }

        //12.原始记录修改原因
        [MaxLength(MaxLength_50)]
        public string AlterReason { get; set; }

        //13.检测地点
        [MaxLength(MaxLength_50)]
        public string Address { get; set; }

        //14.是否为自动检测
        public bool StrFlag { get; set; }

        //15.流程结束
        public bool ProcessEnd { get; set; }

    }
}
