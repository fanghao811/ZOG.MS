using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 18，检定/校准/核查/原始数据附件信息表（BD_Appendix）
    /// </summary>
    [Table("BD_Appendix")]
    public class BD_Appendix : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.TestDevice_ID INT
        [ForeignKey("TestDevice_ID")]
        public BD_TestItem TestDevice { get; set; }
        public long TestDevice_ID { get; set; }

        //4	DeviceName 仪器名称    
        public string DeviceName { get; set; }

        //5	DeviceType 仪器型号    VARCHAR(20)
        public string DeviceType { get; set; }

        //6	DeviceSN 仪器编号    VARCHAR(20)
        public string DeviceSN { get; set; }

        //7	UnitName 单位名称    VARCHAR(20)
        public string UnitName { get; set; }

        //8	Address 文档路径    VARCHAR(20)
        public string Address { get; set; }

        //9	intType 数据类型    INT
        public bool IntType { get; set; }

        public bool IsDeleted { get; set; }
    }

}
