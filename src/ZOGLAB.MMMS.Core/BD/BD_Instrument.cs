using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 1，被检仪器基本信息表（BD_Instrument）
    /// </summary>
    [Table("BD_Instrument")]
    public class BD_Instrument : AuditedEntity<long>
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        [Column("InstrumentId")]
        public override long Id { get; set; }

        //1.站点信息ID   foreignKey site
        public long Site_ID { get; set; }

        //2.仪器出厂编号
        [MaxLength(MaxLength_50)]
        public string SN { get; set; }

        //3.仪器名称
        [MaxLength(MaxLength_20)]
        public string Name { get; set; }

        //4.仪器型号
        [MaxLength(MaxLength_50)]
        public string Model { get; set; }

        //5.准确度等级
        [MaxLength(MaxLength_20)]
        public string Grade { get; set; }

        //6.测量范围
        [MaxLength(MaxLength_20)]
        public string Scope { get; set; }

        //7.分辨力
        [MaxLength(MaxLength_20)]
        public string Power { get; set; }

        //8.制造商
        [MaxLength(MaxLength_50)]
        public string Manufacturer { get; set; }

        //11.备注信息
        [MaxLength(MaxLength_50)]
        public string Mark { get; set; }

        /*多对多关系 12/24/2018 */
        /// <summary>
        /// 检测项目集合：温度检定，温湿度校准，气压核查等
        /// </summary>
        public virtual ICollection<BD_CheckType> CheckTypes { get; set; }

        /*多对多关系 12/24/2018 */
        /// <summary>
        /// 要素类型集合：温，湿，气压等
        /// </summary>
        public virtual ICollection<BD_MeteorType>  MeteorTypes { get; set; }

        //构造函数
        public BD_Instrument()
        {
            CreationTime = DateTime.Now;
        }
    }
}
