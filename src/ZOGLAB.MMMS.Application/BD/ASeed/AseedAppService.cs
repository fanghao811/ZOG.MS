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
    /// <summary>
    /// Application service that is used by 'role management' page.
    /// </summary>
    public class AseedAppService : MMMSAppServiceBase, IAseedAppService
    {
        private readonly IRepository<BD_Instrument, long> _instrumentRepository;

        public AseedAppService(IRepository<BD_Instrument, long> InstrumentRepository)
        {
            _instrumentRepository = InstrumentRepository;

        }

        public async Task<List<BD_Instrument>> GetAll()
        {
            var query = await _instrumentRepository.GetAll().ToListAsync();
            return query;
        }



    }
}
