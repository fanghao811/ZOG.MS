using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 11，计量装置信息表（BD_Installation）
    /// </summary>
    [Table("BD_Installation")]
    public class BD_Installation : CreationAuditedEntity<long>,ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_200 = 200;

        //1.标准编号 
        [MaxLength(MaxLength_20)]
        public string Standard_SN { get; set; }

        //2.标准装置名称
        [MaxLength(MaxLength_50)]
        public string Equipment_Name { get; set; }

        //3.计量标准型号
        public string Equipment_Model { get; set; }

        //4.测量范围
        [MaxLength(MaxLength_50)]
        public string TestRange { get; set; }

        //5.准确度
        [MaxLength(MaxLength_50)]
        public string Accurate { get; set; }

        //6.计量标准证书号
        [MaxLength(MaxLength_50)]
        public string CertificateId { get; set; }

        //7.有效日期
        public DateTime ValidateDate { get; set; }

        //8.发证机构
        [MaxLength(MaxLength_50)]
        public string Organization { get; set; }

        //9.备注
        [MaxLength(MaxLength_50)]
        public string Mark { get; set; }

        public bool IsDeleted { get; set; }
    }
}
