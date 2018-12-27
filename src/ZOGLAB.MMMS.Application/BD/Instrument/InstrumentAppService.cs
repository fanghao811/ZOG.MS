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
    public class InstrumentAppService : MMMSAppServiceBase, IInstrumentAppService
    {
        private readonly IRepository<BD_Instrument, long> _instrumentRepository;

        public InstrumentAppService(IRepository<BD_Instrument, long> instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;

        }

        public List<InstrumentFReadDto> GetAll()
        {
            var query = _instrumentRepository.GetAll().ToList().MapTo<List<InstrumentFReadDto>>();
            return query;
        }
    }
}