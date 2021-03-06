﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// 22，检测项目信息表（BD_CheckType）
    /// </summary>
    [Table("BD_CheckType")]
    public class BD_CheckType : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2	MeteorType_ID 气象要素 INT 外
        [ForeignKey("MeteorTypeId")]
        public virtual BD_MeteorType MeteorType { get; set; }
        public long? MeteorTypeId { get; set; }

        public Calibration_Type CalibrationType { get; set; }

        //3	CheckName 检测项目   VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string CheckName { get; set; }

        //4	Mark 备注  VARCHAR(50)
        [MaxLength(MaxLength_50)]
        public string Mark { get; set; }

        //5	UserName 操作者 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string UserName { get; set; }

        //6	strDateTime 操作日期    VARCHAR(20)
        public DateTime? StrDateTime { get; set; }

        /*多对多关系 12/24/2018 */
        /// <summary>
        /// 检测项目集合：温度检定，温湿度校准，气压核查等
        /// </summary>
        public virtual ICollection<BD_Instrument> Instruments { get; set; }

        //7	strFlag 是否自动检测  INT
        public bool StrFlag { get; set; }

        public bool IsDeleted { get; set; }

        public BD_CheckType() {
            StrFlag = false;
            StrDateTime = DateTime.Now;
        }

        public enum Calibration_Type
        {
            检定 = 1,
            校准 = 2,
            核查 = 3
        }
    }
}
