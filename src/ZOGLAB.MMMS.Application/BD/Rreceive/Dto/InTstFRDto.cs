using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public class InTstFRDto
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        //2.检测项目
        public string CheckType { get; set; }

        //9.物质编码
        [MaxLength(MaxLength_50)]
        public string Number { get; set; }

        //10.有效日期
        [MaxLength(MaxLength_20)]
        public string CaliValidateDate { get; set; }

        //11.不确定度
        [MaxLength(MaxLength_20)]
        public string CaliU { get; set; }

        //13.检测地点
        [MaxLength(MaxLength_50)]
        public string Address { get; set; }

        //14.是否为自动检测
        public bool StrFlag { get; set; }
    }
}
