using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    /*  
     *  public virtual async Task AddToOrganizationUnitAsync(TUser user, OrganizationUnit ou)
        {
            var currentOus = await GetOrganizationUnitsAsync(user);

            if (currentOus.Any(cou => cou.Id == ou.Id))
            {
                return;
            }

            await CheckMaxUserOrganizationUnitMembershipCountAsync(user.TenantId, currentOus.Count + 1);

            await _userOrganizationUnitRepository.InsertAsync(new UserOrganizationUnit(user.TenantId, user.Id, ou.Id));
        }
     * 
     */
    /// <summary>
    /// 思路：仪器添加到主表，方法写在仪器这边
    /// </summary>
    public class InstrumentAppService : MMMSAppServiceBase, IInstrumenttAppService
    {
        private readonly IRepository<BD_Instrument, long> _instrumentRepository;

        public InstrumentAppService(IRepository<BD_Instrument, long> instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;

        }

        public async Task<List<BD_Instrument>> GetAll()
        {
            var query = await _instrumentRepository.GetAll().ToListAsync();
            return query;
        }


    }
}