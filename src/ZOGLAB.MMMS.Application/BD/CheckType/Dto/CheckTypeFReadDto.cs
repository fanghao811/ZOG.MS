using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ZOGLAB.MMMS.BD
{
    [AutoMapFrom(typeof(BD_CheckType))]
    public class CheckTypeFReadDto : EntityDto<long>
    {
        //2	MeteorType_ID 气象要素 INT 外
        public long? MeteorTypeId { get; set; }

        public string Meteor { get; set; }

        //3	CheckName 检测项目   VARCHAR(20)
        public string CheckName { get; set; }
    }
}