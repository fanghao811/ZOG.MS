using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    ///21，气象要素信息表（BD_MeteorType）
    /// </summary>
    [Table("BD_MeteorType")]
    public class BD_MeteorType : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        /// <summary>
        /// Name 要素名称:温度气压、湿度
        /// </summary>
        [MaxLength(MaxLength_20)]
        public string Name { get; set; }

        //3	Mark 备注  VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Mark { get; set; }
 
        public bool IsDeleted { get; set; }

        /*多对多关系 12/24/2018 */
        /// <summary>
        /// 要素类型集合：温，湿，气压等
        /// </summary>
        public virtual ICollection<BD_Instrument> Instruments { get; set; }
    }

}
