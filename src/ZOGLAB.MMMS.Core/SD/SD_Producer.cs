using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 5，通讯信息表（SD_Producer）
    /// </summary>
    [Table("BD_ASeed")]
    public class SD_Producer : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_10 = 10;
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_500 = 500;
        //2	Information_ID 通讯设备ID  INT 外
        public int Information_ID { get; set; }

        //3	ComNum 串口号 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string ComNum { get; set; }

        //4	Baud 波特率 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string Baud { get; set; }

        //5	DataBit 数据位 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string DataBit { get; set; }

        //6	StopBit 停止位 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string StopBit { get; set; }

        //7	ParyBit 校验位 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string ParyBit { get; set; }

        //9	IP IP  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string IP { get; set; }

        //10	Port 端口号 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Port { get; set; }

        //11	Instruct 指令  VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Instruct { get; set; }

        //12	Data_Message 返回报文    VARCHAR(500)
        [MaxLength(MaxLength_500)]
        public string Data_Message { get; set; }

        //13	Type 通讯方式    INT
        public int Type { get; set; }

        public bool IsDeleted { get; set; }
    }

}
