using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 1，系统组织机构表(SD_Organization)
    /// </summary>
    [Table("SD_Organization")]
    public class SD_Organization : Entity<long>, IHasCreationTime
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_200 = 200;

        //1.组织机构编码
        [MaxLength(MaxLength_20)]
        public string Code { get; set; }

        //2.组织机构名称
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //3.父级组织机构ID
        public long ParentOrg_ID { get; set; }

        //4.地址
        [MaxLength(MaxLength_200)]
        public string Address { get; set; }

        //5.电话
        [MaxLength(MaxLength_50)]
        public string Tel { get; set; }

        //6.联系人
        [MaxLength(MaxLength_50)]
        public string Contact { get; set; }

        //7.服务器IP
        [MaxLength(MaxLength_50)]
        public string ServerIP { get; set; }

        //8.服务器名称
        [MaxLength(MaxLength_50)]
        public string ServerName { get; set; }

        //9.是否为本地系统
        /// <summary>
        /// 标明此级组织机构是否为本系统的管理对象
        /// </summary>
        public bool IsLocalSystem { get; set; }

        //10.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_Organization()
        {
            CreationTime = DateTime.Now;
        }
    }
}
