using System.ComponentModel.DataAnnotations;

namespace ZOGLAB.MMMS.SD.MenuTree.Dto
{
    public class MoveMenuTreeUnitInput
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public long? NewParentId { get; set; }
    }
}