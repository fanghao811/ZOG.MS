using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 2，通讯设备信息表（SD_Information）
    /// </summary>
    [Table("SD_Information")]
    public class SD_Information : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	Device_Name 设备名称    VARCAHR(50)
        [MaxLength(MaxLength_50)]
        public string Device_Name { get; set; }

        //3	Model 设备型号    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Model { get; set; }

        //4	Device_SN 设备编号    VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Device_SN { get; set; }

        //5	Manufacturer 制造商 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Manufacturer { get; set; }

        //6	Flag 是否启用    INT	
        public int Flag { get; set; }

        //7	Device_Type 设备类型    INT
        public int Device_Type { get; set; }

        public bool IsDeleted { get; set; }
    }

}
