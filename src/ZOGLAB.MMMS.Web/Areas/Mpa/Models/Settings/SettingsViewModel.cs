using System.Collections.Generic;
using Abp.Application.Services.Dto;
using ZOGLAB.MMMS.Configuration.Tenants.Dto;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}