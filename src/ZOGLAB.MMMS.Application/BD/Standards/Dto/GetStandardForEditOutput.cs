using System.Collections.Generic;
using ZOGLAB.MMMS.Authorization.Permissions.Dto;

namespace ZOGLAB.MMMS.BD
{
    public class GetStandardForEditOutput
    {
        public StandardEditDto Standard { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}