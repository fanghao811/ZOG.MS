using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ZOGLAB.MMMS.BD
{
    [AutoMapFrom(typeof(BD_Receive))]
    public class ReceiveEditDto
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        public long? Id { get; set; }

        //1.送检单位ID 
        public string UnitName { get; set; }
        public long? Unit_ID { get; set; }

        //2.收发单号
        [MaxLength(MaxLength_50)]
        public string Number { get; set; }

        //3.设备数量
        public int? Device_Num { get; set; }

        //2.客户地址
        [MaxLength(MaxLength_50)]
        public string Address { get; set; }

        //2.联系人
        [MaxLength(MaxLength_50)]
        public string Contact { get; set; }

        //2.联系方式
        [MaxLength(MaxLength_20)]
        public string ContactTel { get; set; }

        //6.送检快递单号
        [MaxLength(MaxLength_50)]
        public string ExpressDelivery { get; set; }

    }
}
