using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZOGLAB.MMMS.Authorization.Users;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 6,设备检测项目从表（BD_DeviceItem）
    /// </summary>
    [Table("BD_DeviceItem")]
    public class BD_DeviceItem : CreationAuditedEntity<long>,ISoftDelete
    {
        public const int MaxLength_50 = 50;

        //1.收发单主表ID   foreignKey
        //[ForeignKey("ReceiveDeviceId")]
        public BD_ReceiveDevice BD_ReceiveDevice { get; set; }
        //public long ReceiveDeviceId { get; set; }

        //2.检测单表ID
        //[ForeignKey("Test_ID")]
        public BD_Test BD_Test { get; set; }
        //public long Test_ID { get; set; }

        //3.仪器交接状态
        public bool IntHandover { get; set; }

        //4.仪器接收者ID
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }

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
        public DateTime CaliValidateDate { get; set; }

        //11.不确定度
        [MaxLength(MaxLength_50)]
        public string CaliU95 { get; set; }

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

        public bool IsDeleted { get; set; }

    }
}
