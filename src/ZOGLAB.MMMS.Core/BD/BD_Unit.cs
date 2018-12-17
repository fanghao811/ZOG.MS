using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 9，送检单位信息表（BD_Unit）
    /// </summary>
    [Table("BD_Unit")]
    public class BD_Unit : CreationAuditedEntity<long>,ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //1.单位名称 
        [MaxLength(MaxLength_50)]
        public string UnitName { get; set; }

        //2.单位地址
        public string Address { get; set; }

        //3.联系人
        [MaxLength(MaxLength_50)]
        public string Users { get; set; }

        //4.联系电话
        public string Tel { get; set; }

        //5.邮箱
        [MaxLength(MaxLength_20)]
        public string Email { get; set; }

        //6.传真
        [MaxLength(MaxLength_20)]
        public string FaxNumber { get; set; }

        //7.备注
        public bool Mark { get; set; }

        public bool IsDeleted { get; set; }
    }
}
