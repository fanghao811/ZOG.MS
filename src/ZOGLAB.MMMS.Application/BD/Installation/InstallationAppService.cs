using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// Application service that is used by 'role management' page.
    /// </summary>
    public class InstallationAppService : MMMSAppServiceBase, IInstallationAppService
    {
        private readonly IRepository<BD_Installation, long> _installationdRepository;

        public InstallationAppService(IRepository<BD_Installation, long> installationRepository)
        {
            _installationdRepository = installationRepository;
        }

        public async Task<List<InstallatonListDto>> GetList()
        {
            var query = await _installationdRepository.GetAll()
                .Select(p =>
                new InstallatonListDto
                {
                    Id = p.Id,
                    Installation = p.Equipment_Name + " " + p.Accurate
                }).ToListAsync();

            return query;
        }
    }
}
