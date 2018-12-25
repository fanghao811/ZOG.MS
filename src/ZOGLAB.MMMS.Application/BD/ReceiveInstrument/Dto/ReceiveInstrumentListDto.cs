using Abp.AutoMapper;

namespace ZOGLAB.MMMS.BD
{
    public class ReceiveInstrumentListDto
    {
        public long? Id { get; set; }

        //1.收发单号
        public string UnitName { get; set; }

        //2.收发单号
        public string Number { get; set; }

        //3.设备数量
        public int? Device_Num { get; set; }

        //4.客户地址
        public string Address { get; set; }

        //5.联系人
        public string Conntact { get; set; }

        //6.联系方式
        public string ContactTel { get; set; }

        //7.送检快递单号
        public string ExpressDelivery { get; set; }

    }
}