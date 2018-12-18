using Abp.Extensions;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.BD
{
    public class GetStandardsInput: PagedAndSortedInputDto, IShouldNormalize
    {
        public const int MaxLength_50 = 50;
        public const int MaxLength_20 = 20;

        //1.1   有效日期  -->优先过滤
        public DateTime ValidateDate { get; set; }

        //1.2   标准器类型 -->类型过滤
        public bool StrType { get; set; }

        //2.1   所属计量装置ID -->精确查询
        public long Installation_ID { get; set; }

        //3.1   出厂编号 -->模糊查询
        [MaxLength(MaxLength_20)]
        public string FactoryNum { get; set; }

        //3.2   标准器名称   
        [MaxLength(MaxLength_50)]
        public string StrName { get; set; }

        //3.3   标准器型号
        [MaxLength(MaxLength_20)]
        public string StrSpec { get; set; }



        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "ExecutionTime DESC";
            }

            if (Sorting.IndexOf("UserName", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                Sorting = "User." + Sorting;
            }
            else
            {
                Sorting = "AuditLog." + Sorting;
            }
        }
    }
}
