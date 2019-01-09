using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace ZOGLAB.MMMS.BD
{
    public class InTstListDto:EntityDto<long>
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.仪器名称
        public string InstrumentName { get; set; }

        //2.仪器类型
        //public string InstrumentType { get; set; }

        //3.物质编码
        [MaxLength(MaxLength_50)]
        public string Number { get; set; }

        //4.检测项目
        public string CheckType { get; set; }
        public long? CheckTypeId { get; set; }

        //5.有效日期
        public string CaliValidate { get; set; }

        //6.仪器交接状态
        public bool IntHandover { get; set; }

        //7.仪器接收者ID
        public string User { get; set; }
        public long?  UserId { get; set; }

        //8.仪器挑选状态
        public bool Calibration { get; set; }

        //10.不确定度
        [MaxLength(MaxLength_20)]
        public string CaliU { get; set; }

        //11.检测地点
        [MaxLength(MaxLength_50)]
        public string Address { get; set; }

        //12.是否为自动检测
        public bool StrFlag { get; set; }

        //12.生成时间
        public DateTime? CreationTime { get; set; }

    }
}
