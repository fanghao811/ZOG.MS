using Abp.Extensions;
using Abp.Runtime.Validation;
using System.ComponentModel.DataAnnotations;
using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.BD
{
    public class GetUnitsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public const int MaxLength_50 = 50;
        public const int MaxLength_20 = 20;

        //1.单位名称 
        [MaxLength(MaxLength_50)]
        public string UnitName { get; set; }

        //2.单位地址
        public string Address { get; set; }

        //3.联系人
        [MaxLength(MaxLength_50)]
        public string Contact { get; set; }

        //4.联系电话
        public string ContactTel { get; set; }

        //5.邮箱
        [MaxLength(MaxLength_20)]
        public string Email { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "UnitName DESC";
            }

        }

    }
}
