using System.Threading.Tasks;
using Abp.Application.Services;
using ZOGLAB.MMMS.Configuration.Host.Dto;

namespace ZOGLAB.MMMS.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
