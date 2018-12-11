using Abp.Application.Services;
using ZOGLAB.MMMS.Tenants.Dashboard.Dto;

namespace ZOGLAB.MMMS.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
