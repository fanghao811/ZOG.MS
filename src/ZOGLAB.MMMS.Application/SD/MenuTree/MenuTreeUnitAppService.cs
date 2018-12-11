using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZOGLAB.MMMS.SD;

namespace ZOGLAB.MMMS.MenuTree
{
    //[AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits)]
    public class MenuTreeUnitAppService : MMMSAppServiceBase, IMenuTreeUnitAppService
    {
        private readonly TreeUnitManager<SD_MenuTreeUnit> _treeUnitManager;
        private readonly IRepository<SD_MenuTreeUnit, long> _treeUnitRepository;


        public MenuTreeUnitAppService(
            TreeUnitManager<SD_MenuTreeUnit> treeUnitManager,
            IRepository<SD_MenuTreeUnit, long> treeUnitRepository
            )
        {
            _treeUnitManager = treeUnitManager;
            _treeUnitRepository = treeUnitRepository;

        }

        public ListResultDto<MenuTreeUnitDto> GetMenuTreeUnits()
        {
            var query = _treeUnitRepository.GetAll().ToList();
            //Exp: AutoMapper.Map 实战一: List--> ListResultDto
            return new ListResultDto<MenuTreeUnitDto>
            {
                Items = Mapper.Map<List<SD_MenuTreeUnit>, List<MenuTreeUnitDto>>(query)
            };
        }

        public async Task<MenuTreeUnitDto> CreateOrganizationUnit(CreateTreeUnitInput input)
        {
            var menuTreeUnit = new SD_MenuTreeUnit(input.DisplayName, input.Url, input.Icon, input.ParentId);

            await _treeUnitManager.CreateAsync(menuTreeUnit);
            await CurrentUnitOfWork.SaveChangesAsync();

            return menuTreeUnit.MapTo<MenuTreeUnitDto>();
        }
    }
}