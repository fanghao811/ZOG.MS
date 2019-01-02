using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public class InstrumentWithTCountDto
    {
        public long Id { get; set; }

        //2.仪器出厂编号
        public string SN { get; set; }

        //3.仪器名称
        public string Name { get; set; }

        //4.仪器型号
        public string Model { get; set; }

        //5.检测项目数量
        public int CheckTypeCount { get; set; }
    }
}
