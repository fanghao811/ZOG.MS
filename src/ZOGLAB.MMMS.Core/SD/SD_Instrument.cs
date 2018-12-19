using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 6，被检仪器基本信息表（SD_Instrument）
    /// </summary>
    [Table("SD_Instrument")]
    public class SD_Instrument : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        //2	SN 仪器出厂编号  VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string SN { get; set; }

        //3	Name 仪器名称    VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string UseNamers { get; set; }

        //4	Model 仪器型号    VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Model { get; set; }

        //5	Grade 准确度等级   VARCHAR(20)
        [MaxLength(MaxLength_50)]
        public string Grade { get; set; }

        //6	Scope 测量范围    VARCHAR(20)
        [MaxLength(MaxLength_50)]
        public string Scope { get; set; }

        //7	Power 分辨力 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Power { get; set; }

        //8	Manufacturer 制造商 VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Manufacturer { get; set; }

        //9	CheckType_ID 检测项目ID  INT
        public int CheckType_ID { get; set; }

        //10	Mark 备注信息    VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Mark { get; set; }

        //11	FoundUser 操作者 VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string FoundUser { get; set; }

        public bool IsDeleted { get; set; }
    }

}
