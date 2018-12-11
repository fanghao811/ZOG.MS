using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ZOGLAB.MMMS.Authorization.Permissions.Dto;

namespace ZOGLAB.MMMS.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
