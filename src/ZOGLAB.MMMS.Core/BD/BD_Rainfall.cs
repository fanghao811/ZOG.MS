using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 15，雨量检测数据表（BD_Rainfall）
    /// </summary>
    [Table("BD_Rainfall")]
    public class BD_Rainfall : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.TestDevice_ID INT
        [ForeignKey("TestDevice_ID")]
        public BD_TestItem TestDevice { get; set; }
        public long TestDevice_ID { get; set; }

        //intDataID 读数序号    INT
        public int IntDataID { get; set; }

        //StandVal    雨强 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StandVal { get; set; }

        //StandRevisedVal 雨量  VARCHAR(20)
        [MaxLength(MaxLength_50)]
        public string StandRevisedVal { get; set; }

        //StandReal 标准值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string StandReal { get; set; }

        //ViewVal 示值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string ViewVal { get; set; }

        //DiffPressVal 误差值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string DiffPressVal { get; set; }

        //intType 数据类型    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string IntType { get; set; }

        //intCaliPointIndex 检测点序号   INT
        public int IntCaliPointIndex { get; set; }

        //strDateTime 检测时间 VARCHAR(20)
        public DateTime StrDateTime { get; set; }

        //CheckType 检测类型    INT
        public bool CheckType { get; set; }

        //Types   数据采集方式 INT
        public bool Types { get; set; }

        public bool IsDeleted { get; set; }
    }

}
