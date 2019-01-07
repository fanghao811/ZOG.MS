using System;
using System.ComponentModel.DataAnnotations;

namespace ZOGLAB.MMMS.BD
{
    public class TestListDto
    {
        public const int MaxLength_50 = 50;

        public long? Id { get; set; }

        //1.计量装置ID
        public string Installation { get; set; }

        //2.检测单号
        [MaxLength(MaxLength_50)]
        public string Check_Num { get; set; }

        //3.检测要素
        [MaxLength(MaxLength_50)]
        public string MeteorType { get; set; }

        //4.检测开始时间
        public DateTime? StartDate { get; set; }

        //5.结束时间
        public DateTime? FinishDate { get; set; }

        //6.接收人
        public string User { get; set; }

        //7.业务类型
        public string VocationalWorkType { get; set; }

        //8.备注
        public string Mark { get; set; }
    }
}