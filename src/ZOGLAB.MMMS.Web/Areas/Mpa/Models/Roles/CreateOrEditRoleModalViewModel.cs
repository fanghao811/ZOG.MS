using Abp.AutoMapper;
using ZOGLAB.MMMS.Authorization.Roles.Dto;
using ZOGLAB.MMMS.Web.Areas.Mpa.Models.Common;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}