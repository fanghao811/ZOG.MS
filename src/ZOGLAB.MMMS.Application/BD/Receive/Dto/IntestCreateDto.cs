using System.ComponentModel.DataAnnotations;
namespace ZOGLAB.MMMS.BD
{
    public class IntestEditDto
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        public long? Id { get; set; }
        //2.1收发单从表ID
        public long? ReceiveInstrument_ID { get; set; }

        //2.2检测单表ID
        public long? CheckType_ID { get; set; }
        public string CheckName { get; set; }


        //9.物质编码
        [MaxLength(MaxLength_50)]
        public string Number { get; set; }

        //10.有效日期
        [MaxLength(MaxLength_20)]
        public string CaliValidate { get; set; }

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
