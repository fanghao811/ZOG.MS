using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 8,用户操作日志表(SD_UserLog)
    /// </summary>
    [Table("SD_UserLog")]
    public class SD_UserLog : Entity<long>, IHasCreationTime
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_200 = 200;

        //1.操作类型
        [MaxLength(MaxLength_20)]
        public string ActionType { get; set; }

        //2.操作页面(功能项名称)
        [MaxLength(MaxLength_50)]
        public string ActionPage { get; set; }

        //3.动作内容
        [MaxLength(MaxLength_200)]
        public string ActionContent { get; set; }

        //4.User_ID -->SYS_User.ID 外键
        public long User_ID { get; set; }
        [ForeignKey("User_ID")]
        public SD_User SD_User { get; set; }

        //5.操作员
        [MaxLength(MaxLength_50)]
        public string OperatorName { get; set; }

        //6.所在电脑设备名称
        public string OperateDevice { get; set; }

        //7.电脑IP
        [MaxLength(MaxLength_20)]
        public string OperateIP { get; set; }

        //8.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_UserLog()
        {
            CreationTime = DateTime.Now;
        }
    }
}
