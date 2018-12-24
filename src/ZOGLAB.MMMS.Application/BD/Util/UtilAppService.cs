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
    public class UnitAppService : MMMSAppServiceBase, IUnitAppService
    {
        private readonly IRepository<BD_Unit, long> _unitRepository;

        public UnitAppService(IRepository<BD_Unit, long> unitRepository)
        {
            _unitRepository = unitRepository;

        }

        public async Task<List<BD_Unit>> GetAll()
        {
            var query = await _unitRepository.GetAll().ToListAsync();
            return query;
        }

        /// <summary>
        /// 过滤，排序，分页 获取标准器列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<UnitListDto>> GetUnits(GetUnitsInput input)
        {
            var query = CreateStandardsQuery(input);    //Step 01

            var resultCount = await query.CountAsync(); //Step 02

            var results = await query
                .AsNoTracking()
                .OrderBy(input.Sorting) /*Exp: using System.Linq.Dynamic;*/
                .PageBy(input)
                .ToListAsync();
            var unitListDtos = results.MapTo<List<UnitListDto>>(); //Step 03

            return new PagedResultDto<UnitListDto>(resultCount, unitListDtos);  //Step 04
        }

        private IQueryable<BD_Unit> CreateStandardsQuery(GetUnitsInput input)
        {
            var query = _unitRepository.GetAll()
                        .WhereIf(!input.UnitName.IsNullOrWhiteSpace(), item => item.UnitName.Contains(input.UnitName)) //公司名
                        .WhereIf(!input.Address.IsNullOrWhiteSpace(), item => item.Address.Contains(input.Address)) //地址
                        .WhereIf(!input.Email.IsNullOrWhiteSpace(), item => item.Email.Contains(input.Email))
                        .WhereIf(!input.Contact.IsNullOrWhiteSpace(), item => item.Contact.Contains(input.Contact))//联系人
                        .WhereIf(!input.ContactTel.IsNullOrWhiteSpace(), item => item.ContactTel.Contains(input.ContactTel)); //联系人电话                                                                                                             
            return query;
        }

    }
}
