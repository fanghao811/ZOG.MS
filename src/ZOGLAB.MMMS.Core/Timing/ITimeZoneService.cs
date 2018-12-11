using System.Threading.Tasks;
using Abp.Configuration;

namespace ZOGLAB.MMMS.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
