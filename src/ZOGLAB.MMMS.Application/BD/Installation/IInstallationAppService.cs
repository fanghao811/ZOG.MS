using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IInstallationAppService : IApplicationService
    {
        Task<List<InstallatonListDto>> GetList(); 
    }
}
