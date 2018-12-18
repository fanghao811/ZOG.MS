using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 19，站点信息表（BD_Site）
    /// </summary>
    [Table("BD_Site")]
    public class BD_Site : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	Organization_ID 系统组织机构ID    INT 外
        [ForeignKey("OrganizationUnit_ID")]
        public OrganizationUnit OrganizationUnit { get; set; }
        public long OrganizationUnit_ID { get; set; }

        //3	SiteNum 站号  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Users { get; set; }

        //4	SiteName 站名  VARCHAR(50)
        [MaxLength(MaxLength_20)]
        public string SiteName { get; set; }

        //5	ProvinceName 所在省市    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string ProvinceName { get; set; }

        //6	Longitude 经度  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Longitude { get; set; }

        //7	Latitude 纬度  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string Latitude { get; set; }

        //8	Address 站点地址    VARCHAR(20)
        [MaxLength(MaxLength_50)]
        public string Address { get; set; }

        //9	NumCount 站点要素数   INT	
        public int NumCount { get; set; }

        //10	intType 站点类型    INT
        public bool IntType { get; set; }

        //2.返样数量
        public int BackNumber { get; set; }

        public bool IsDeleted { get; set; }
    }

}
