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
    public class CheckTypeAppService : MMMSAppServiceBase, ICheckTypeAppService
    {
        private readonly IRepository<BD_CheckType, long> _checkTypeRepository;

        public CheckTypeAppService(IRepository<BD_CheckType, long> checkTypeRepository)
        {
            _checkTypeRepository = checkTypeRepository;

        }

        public async Task<List<CheckTypeFReadDto>> GetAll()
        {
            var query = await _checkTypeRepository.GetAll()
                .Include("BD_MeteorType")
                .Select(p => 
                new CheckTypeFReadDto {
                    Id = p.Id,
                    CheckName=p.CheckName,
                    MeteorTypeId =p.MeteorTypeId,
                    Meteor=p.MeteorType.Name
                })
                .ToListAsync();
            return query.MapTo<List<CheckTypeFReadDto>>();
        }

    }
}
