using System.ComponentModel.DataAnnotations;
using Abp.Organizations;

namespace ZOGLAB.MMMS.SD.MenuTree.Dto
{
    public class UpdateMenuTreeUnitInput
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        [Required]
        [StringLength(OrganizationUnit.MaxDisplayNameLength)]
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}