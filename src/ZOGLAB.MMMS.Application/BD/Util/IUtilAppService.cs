using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IUnitAppService : IApplicationService
    {
        Task<PagedResultDto<UnitListDto>> GetUnits(GetUnitsInput input);
    }
}
