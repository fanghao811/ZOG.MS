using Abp.AutoMapper;
using ZOGLAB.MMMS.MultiTenancy;
using ZOGLAB.MMMS.MultiTenancy.Dto;
using ZOGLAB.MMMS.Web.Areas.Mpa.Models.Common;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesForEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}