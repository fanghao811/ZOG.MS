using System.Collections.Generic;
using Abp.Application.Services.Dto;
using ZOGLAB.MMMS.Editions.Dto;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}