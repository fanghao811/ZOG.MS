using System.Collections.Generic;

namespace ZOGLAB.MMMS.SD
{
    public interface ITreeUnit
    {
        ICollection<ITreeUnit> Children { get; set; }
        string Code { get; set; }
        string DisplayName { get; set; }
        ITreeUnit Parent { get; set; }
        long? ParentId { get; set; }
        //5:00001.00002
        int CodeUnitLength { get; }
    }
}