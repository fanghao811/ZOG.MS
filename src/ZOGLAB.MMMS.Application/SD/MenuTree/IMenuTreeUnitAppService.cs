using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


namespace ZOGLAB.MMMS.MenuTree
{
    public interface IMenuTreeUnitAppService : IApplicationService
    {
        ListResultDto<MenuTreeUnitDto> GetMenuTreeUnits();

        //Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitUsers(GetOrganizationUnitUsersInput input);

        Task<MenuTreeUnitDto> CreateOrganizationUnit(CreateTreeUnitInput input);

        //Task<OrganizationUnitDto> UpdateOrganizationUnit(UpdateOrganizationUnitInput input);

        //Task<OrganizationUnitDto> MoveOrganizationUnit(MoveOrganizationUnitInput input);

        //Task DeleteOrganizationUnit(EntityDto<long> input);

        //Task AddUserToOrganizationUnit(UserToOrganizationUnitInput input);

        //Task RemoveUserFromOrganizationUnit(UserToOrganizationUnitInput input);

        //Task<bool> IsInOrganizationUnit(UserToOrganizationUnitInput input);
    }
}
