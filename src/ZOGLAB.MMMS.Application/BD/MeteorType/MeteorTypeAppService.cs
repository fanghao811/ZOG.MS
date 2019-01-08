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
    public class MeteorTypeAppService : MMMSAppServiceBase, IMeteorTypeAppService
    {
        private readonly IRepository<BD_MeteorType, long> _meteorTypeRepository;

        public MeteorTypeAppService(IRepository<BD_MeteorType, long> meteorTypeRepository)
        {
            _meteorTypeRepository = meteorTypeRepository;

        }

        public async Task<List<MeteorTypeListDto>> GetAll()
        {
            var query = await _meteorTypeRepository.GetAll()
                .Select(p => 
                new MeteorTypeListDto
                {
                    Id = p.Id,
                    Meteor=p.Name
                })
                .ToListAsync();
            return query.MapTo<List<MeteorTypeListDto>>();
        }

    }
}
