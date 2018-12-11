using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 7,系统配置表(SD_Parameter)
    /// </summary>
    [Table("SD_Parameter")]
    public class SD_Parameter : Entity<long>, IHasCreationTime
    {
        //1.配置项编码
        public string Code { get; set; }
        //2.配置项名称
        public string Name { get; set; }
        //3.设置有效值
        public string Value { get; set; }
        //4.配置项描述
        public string Description { get; set; }
        //5.备注信息
        public string Memo { get; set; }

        //3.录入日期
        public DateTime CreationTime { get; set; }

        //构造函数
        public SD_Parameter()
        {
            CreationTime = DateTime.Now;
        }
    }
}
