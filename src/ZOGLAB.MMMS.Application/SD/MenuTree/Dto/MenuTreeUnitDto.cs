using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ZOGLAB.MMMS.SD;

namespace ZOGLAB.MMMS.MenuTree
{
    [AutoMapFrom(typeof(SD_MenuTreeUnit))]
    public class MenuTreeUnitDto : AuditedEntityDto<long>
    {
        public long? ParentId { get; set; }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }
    }
}