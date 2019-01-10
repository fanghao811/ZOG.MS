using Abp.Extensions;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using ZOGLAB.MMMS.Dto;
using static ZOGLAB.MMMS.BD.BD_Test;

namespace ZOGLAB.MMMS.BD
{
    public class GetTestsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public const int MaxLength_50 = 50;

        //2.检测单号
        [MaxLength(MaxLength_50)]
        public string Check_Num { get; set; }

        //3.检测要素
        public long? MeteorType_ID { get; set; }

        //4.检测开始时间
        public DateTime StartDate { get; set; }

        //5.结束时间
        public DateTime EndDate { get; set; }

        //7.业务类型
        public VWType? VocationalWorkType { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "Check_Num DESC";
            }
        }
    }
}