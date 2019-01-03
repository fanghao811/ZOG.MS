using Abp.Extensions;
using Abp.Runtime.Validation;
using System.ComponentModel.DataAnnotations;
using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.BD
{
    public class GetInstrumentTestsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public const int MaxLength_50 = 50;
        public const int MaxLength_20 = 20;

        //1.检测项目
        public long? CheckTypeId { get; set; }

        //2.仪器交接状态
        public bool IntHandover { get; set; }

        //3.仪器接收者ID
        public long? UserId { get; set; }

        //4.物质编码
        [MaxLength(MaxLength_50)]
        public string Number { get; set; }

        //5.检测地点
        [MaxLength(MaxLength_50)]
        public string Address { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "Number DESC";
            }
        }
    }
}