using System.Collections.Generic;
using Abp.Application.Services.Dto;
using ZOGLAB.MMMS.Authorization.Permissions.Dto;

namespace ZOGLAB.MMMS.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}