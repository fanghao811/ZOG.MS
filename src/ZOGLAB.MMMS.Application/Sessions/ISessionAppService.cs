using System.Threading.Tasks;
using Abp.Application.Services;
using ZOGLAB.MMMS.Sessions.Dto;

namespace ZOGLAB.MMMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
