using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 12，标准器信息表（BD_Standard）
    /// </summary>
    [Table("BD_Standard")]
    public class BD_Standard : CreationAuditedEntity<long>,ISoftDelete
    {
        public const int MaxLength_50 = 50;
        public const int MaxLength_20 = 20;

        //1.出厂编号
        [MaxLength(MaxLength_20)]
        public string FactoryNum { get; set; }

        //2.标准器名称   
        [MaxLength(MaxLength_50)]
        public BD_DeviceItem DeviceItem { get; set; }
        public string SstrName { get; set; }

        //3.标准器型号
        [MaxLength(MaxLength_20)]
        public string StrSpec { get; set; }

        //4.制造商
        [MaxLength(MaxLength_50)]
        public string Manufactor { get; set; }

        //5.厂家电话
        [MaxLength(MaxLength_20)]
        public string ManufactorTel { get; set; }

        //6.检定单位
        [MaxLength(MaxLength_50)]
        public string CaliFactory { get; set; }

        //7.检定单位联系人
        [MaxLength(MaxLength_20)]
        public string CaliFactoryMan { get; set; }

        //8.检定单位电话
        [MaxLength(MaxLength_20)]
        public string CaliFactoryTel { get; set; }

        //9.所属计量装置ID
        [ForeignKey("Installation_ID")]
        public BD_Installation BD_Installation { get; set; }
        public long Installation_ID { get; set; }

        //10.责任人
        [MaxLength(MaxLength_20)]
        public string ResponsibleMan { get; set; }

        //11.有效日期
        public DateTime ValidateDate { get; set; }

        //12.测量范围
        public bool TestRange { get; set; }

        //13.准确度
        public DateTime Accurate { get; set; }

        //14.校准系数
        [MaxLength(MaxLength_20)]
        public string StrK { get; set; }

        //15.证书号
        [MaxLength(MaxLength_50)]
        public string CertNum { get; set; }

        //16.标准器类型
        public bool StrType { get; set; }

        //17.备注
        public bool ForApprove { get; set; }

        public bool IsDeleted { get; set; }
    }
}
