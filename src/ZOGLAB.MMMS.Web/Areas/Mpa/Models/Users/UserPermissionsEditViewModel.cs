using Abp.AutoMapper;
using ZOGLAB.MMMS.Authorization.Users;
using ZOGLAB.MMMS.Authorization.Users.Dto;
using ZOGLAB.MMMS.Web.Areas.Mpa.Models.Common;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}