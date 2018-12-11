using Abp.AutoMapper;
using ZOGLAB.MMMS.Editions.Dto;
using ZOGLAB.MMMS.Web.Areas.Mpa.Models.Common;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Editions
{
    [AutoMapFrom(typeof(GetEditionForEditOutput))]
    public class CreateOrEditEditionModalViewModel : GetEditionForEditOutput, IFeatureEditViewModel
    {
        public bool IsEditMode
        {
            get { return Edition.Id.HasValue; }
        }

        public CreateOrEditEditionModalViewModel(GetEditionForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}