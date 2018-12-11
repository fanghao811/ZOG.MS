using System.Collections.Generic;
using ZOGLAB.MMMS.Caching.Dto;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}