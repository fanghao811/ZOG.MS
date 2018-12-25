using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ZOGLAB.MMMS.BD
{
    [AutoMapFrom(typeof(BD_ReceiveInstrument))]
    public class ReceiveInstrumentEditDto
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        public long? Id { get; set; }

        //1.收发单号ID   foreignKey
        public long Receive_ID { get; set; }

        //2.被检仪器ID   foreignKey
        public long Instrument_ID { get; set; }

        //3.客户需求
        [MaxLength(MaxLength_50)]
        public string UnitMark { get; set; }

        //4.返样单ID
        public long? Back_ID { get; set; }

    }
}
