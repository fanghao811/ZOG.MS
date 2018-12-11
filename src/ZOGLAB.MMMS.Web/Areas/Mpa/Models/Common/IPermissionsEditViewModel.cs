using System.Collections.Generic;
using ZOGLAB.MMMS.Authorization.Permissions.Dto;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}