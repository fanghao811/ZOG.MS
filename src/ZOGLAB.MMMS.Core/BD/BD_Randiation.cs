using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 16，辐射检测数据表（BD_Randiation）
    /// </summary>
    [Table("BD_Randiation")]
    public class BD_Randiation : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.TestDevice_ID INT
        [ForeignKey("TestDevice_ID")]
        public BD_TestDevice TestDevice { get; set; }
        public long TestDevice_ID { get; set; }

        //intDataID 读数序号    INT
        public int IntDataID { get; set; }

        //MaxVal 最大值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string MaxVal { get; set; }

        //ZeroVal 零点  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string MaxVZeroValal { get; set; }

        //Val 示值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Val { get; set; }

        //T1 时间1 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string T1 { get; set; }

        //T2 时间2 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string T2 { get; set; }

        //T3 时间3 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string T3 { get; set; }

        //Tbegin 开始时间    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Tbegin { get; set; }

        //Tend 结束时间    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Tend { get; set; }

        //RES 阻值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string MaxVaRESl { get; set; }

        // Wind 风速  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Wind { get; set; }

        //intType 数据类型    INT
        public bool IntType { get; set; }

        //CheckType   检测类型 INT
        public bool CheckType { get; set; }

        //Types 数据采集方式  INT
        public bool Types { get; set; }

        public bool IsDeleted { get; set; }
    }

}
