using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ZOGLAB.MMMS.BD
{
    [AutoMapFrom(typeof(BD_Instrument))]
    public class InstrumentFReadDto : EntityDto<long>
    {
        //2.仪器出厂编号
        public string SN { get; set; }

        //3.仪器名称
        public string Name { get; set; }

        //4.仪器型号
        public string Model { get; set; }

        //5.准确度等级
        public string Grade { get; set; }

        //6.测量范围
        public string Scope { get; set; }

    }
}