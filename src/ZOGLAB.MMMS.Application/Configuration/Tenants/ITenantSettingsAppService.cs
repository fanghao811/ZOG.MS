using System.Threading.Tasks;
using Abp.Application.Services;
using ZOGLAB.MMMS.Configuration.Tenants.Dto;

namespace ZOGLAB.MMMS.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
