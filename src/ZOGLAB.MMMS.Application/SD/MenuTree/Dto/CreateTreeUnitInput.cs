using System.ComponentModel.DataAnnotations;
using ZOGLAB.MMMS.SD;

namespace ZOGLAB.MMMS.MenuTree
{
    public class CreateTreeUnitInput
    {
        public long? ParentId { get; set; }

        [Required]
        [StringLength(SD_MenuTreeUnit.MaxDisplayNameLength)]
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}