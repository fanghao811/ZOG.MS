using Abp.Extensions;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ZOGLAB.MMMS.BD.BD_Test;

namespace ZOGLAB.MMMS.BD
{
    public class TestEditDto
    {
        public const int MaxLength_50 = 50;

        public long? Id { get; set; }

        //1.计量装置ID
        public string Installation { get; set; }
        public long? Installation_ID { get; set; }

        //2.检测单号
        [MaxLength(MaxLength_50)]
        public string Check_Num { get; set; }

        //3.检测要素
        [MaxLength(MaxLength_50)]
        public string MeteorType { get; set; }
        public long? MeteorType_ID { get; set; }

        //4.检测开始时间
        public DateTime? StartDate { get; set; }

        //5.结束时间
        public DateTime? FinishDate { get; set; }

        //6.站点ID
        public string Site { get; set; }

        //7.业务类型
        public VWType VocationalWorkType { get; set; }

        //8.备注
        public string Mark { get; set; }

        public long? CreatorUserId { get; set; }

        public long[] InstrumentTestIds { get; set; }

    }
}