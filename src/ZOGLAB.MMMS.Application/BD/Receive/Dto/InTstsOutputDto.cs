using System.Collections.Generic;

namespace ZOGLAB.MMMS.BD
{
    public class InTstsOutputDto
    {
        public List<InTstSelectionDto> UnCheckedItems { get; set; }
        public List<InTstSelectionDto> CheckedItems { get; set; }
    }
}