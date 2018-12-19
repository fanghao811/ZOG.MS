using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using ZOGLAB.MMMS.Authorization;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// Application service that is used by 'role management' page.
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_BD_Standard)]
    public class StandardAppService : MMMSAppServiceBase, IStandardAppService
    {
        private readonly IRepository<BD_Standard, long> _standardRepository;

        public StandardAppService(IRepository<BD_Standard, long> standardRepository)
        {
            _standardRepository = standardRepository;

        }
        /// <summary>
        /// 过滤，排序，分页 获取标准器列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<StandardListDto>> GetStandards(GetStandardsInput input)
        {
            var query = CreateStandardsQuery(input);    //Step 01

            var resultCount = await query.CountAsync(); //Step 02

            var results = await query
                .AsNoTracking()
                .OrderBy(input.Sorting) /*Exp: using System.Linq.Dynamic;*/
                .PageBy(input)
                .ToListAsync();

            var standardListDtos = results.MapTo<List<StandardListDto>>(); //Step 03

            return new PagedResultDto<StandardListDto>(resultCount, standardListDtos);  //Step 04

        }

        [AbpAuthorize(AppPermissions.Pages_BD_Standard_Create, AppPermissions.Pages_BD_Standard_Edit)]
        public  StandardEditDto GetStandardForEdit(NullableIdDto<long> input)
        {
            //Standard   standard
            StandardEditDto standardEditDto;

            if (input.Id.HasValue) //Editing existing role?
            {
                Debug.Assert(input.Id != null, "修改时ID不得为空.");
                var standard = _standardRepository.Get(input.Id.Value);

                standardEditDto = standard.MapTo<StandardEditDto>();
            }
            else
            {
                standardEditDto = new StandardEditDto();
            }
            return standardEditDto;
        }

        [AbpAuthorize(AppPermissions.Pages_BD_Standard_Create, AppPermissions.Pages_BD_Standard_Edit)]
        public async Task CreateOrUpdateStandard(StandardEditDto input)
        {
            BD_Standard item = input.MapTo<BD_Standard>();
            await _standardRepository.InsertOrUpdateAsync(item);
        }

        [AbpAuthorize(AppPermissions.Pages_BD_Standard_Delete)]
        public void DeleteStandard(EntityDto<long> input)
        {
            //Retrieving a task entity with given id using standard Get method of repositories.
            var standard = _standardRepository.Get(input.Id);

            if (standard == null)
            {
                throw new Exception("没有找到对应的标准器，无法删除！");
            }

            //Delete entity with standard Delete method of repositories.
            _standardRepository.Delete(standard);
        }

        private IQueryable<BD_Standard> CreateStandardsQuery(GetStandardsInput input)
        {
            var query = _standardRepository.GetAll()
                .Include(s => s.Installation)
                .Where(s => s.ValidateDate >= input.ValidateDate && s.StrType == input.StrType);

            query = query
                    .WhereIf(input.Installation_ID > 0, item => item.Installation_ID == input.Installation_ID)  //所属计量装置ID -->精确查询
                    .WhereIf(!input.FactoryNum.IsNullOrWhiteSpace(), item => item.FactoryNum.Contains(input.FactoryNum)) //出厂编号 -->模糊查询
                    .WhereIf(!input.StrName.IsNullOrWhiteSpace(), item => item.StrName.Contains(input.StrName)) //标准器名称
                    .WhereIf(!input.StrSpec.IsNullOrWhiteSpace(), item => item.StrSpec.Contains(input.StrSpec)); //标准器型号                                                                                                               

            return query;
        }

    }
}
