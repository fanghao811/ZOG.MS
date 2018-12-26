using System.Collections.Generic;

namespace ZOGLAB.MMMS.BD
{
    public class ReceiveWithItemsDto
    {
        //1.收发ID 
        public long ReceiveId { get; set; }

        //2.收发单号
        public string Number { get; set; }

        //3.送检单位 
        public string UnitName { get; set; }

        public List<InstrumentFReadDto> RegistedInstruments{ get; set; }        //TODO:只传ID列表，前端自己过滤
    }
}