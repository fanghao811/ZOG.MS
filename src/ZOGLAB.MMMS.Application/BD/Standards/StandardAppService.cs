using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using ZOGLAB.MMMS.Authorization;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// Application service that is used by 'role management' page.
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Administration_Roles)]
    public class StandardAppService : MMMSAppServiceBase, IStandardAppService
    {
        private readonly IRepository<BD_Standard, long> _standardRepository;
        
        public StandardAppService(IRepository<BD_Standard, long> standardRepository)
        {
            _standardRepository = standardRepository;
        }

        public async Task<PagedResultDto<StandardListDto>> GetStandards(GetStandardsInput input)
        {
            var query = CreateStandardsQuery(input);    //Step 01

            var resultCount = await query.CountAsync(); //Step 02

            var results = await query
                .AsNoTracking()
                .OrderBy(input.Sorting) /*Exp: using System.Linq.Dynamic;*/
                .PageBy(input)
                .ToListAsync();

            var standardListDtos = ConvertToStandardListDtos(results);  //Step 03

            return new PagedResultDto<StandardListDto>(resultCount, standardListDtos);  //Step 04

        }

        private IQueryable<BD_Standard> CreateStandardsQuery(GetStandardsInput input)
        {
            var query = from standard in _standardRepository.GetAll()
                        //join installation in _standardRepository.GetAll() on installation. equals user.Id into userJoin
                        where standard.ValidateDate >= input.ValidateDate & standard.StrType == input.StrType
                        select standard;        //有效日期  & 标准器类型

            query = query
                    .WhereIf(!input.FactoryNum.IsNullOrWhiteSpace(), item => item.FactoryNum.Contains(input.FactoryNum)) //出厂编号 -->模糊查询
                    .WhereIf(!input.StrName.IsNullOrWhiteSpace(), item => item.StrName.Contains(input.StrName)) //标准器名称
                    .WhereIf(!input.StrSpec.IsNullOrWhiteSpace(), item => item.StrSpec.Contains(input.StrSpec)) //标准器型号                                                                                                               
                    .WhereIf(input.Installation_ID > 0, item => item.Installation_ID == input.Installation_ID); //所属计量装置ID -->精确查询

            return query;
        }

        private List<StandardListDto> ConvertToStandardListDtos(object results)
        {
            throw new NotImplementedException();
        }

    }
}
