using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ZOGLAB.MMMS.BD
{
    [AutoMapFrom(typeof(BD_Instrument))]
    public class InstrmentListDto : EntityDto<long>
    {
        //1.单位名称 
        public string UnitName { get; set; }

        //2.单位地址
        public string Address { get; set; }

        //3.联系人
        public string Contact { get; set; }

        //4.联系电话
        public string ContactTel { get; set; }

        //5.邮箱
        public string Email { get; set; }

        //6.传真
        public string FaxNumber { get; set; }

        //7.备注
        public string Mark { get; set; }

    }
}