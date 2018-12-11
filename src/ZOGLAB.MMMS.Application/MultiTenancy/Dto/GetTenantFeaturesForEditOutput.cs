using System.Collections.Generic;
using Abp.Application.Services.Dto;
using ZOGLAB.MMMS.Editions.Dto;

namespace ZOGLAB.MMMS.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}