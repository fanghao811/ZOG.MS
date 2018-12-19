using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IStandardAppService: IApplicationService
    {
        Task<PagedResultDto<StandardListDto>> GetStandards(GetStandardsInput input);

        StandardEditDto GetStandardForEdit(NullableIdDto<long> input);

        Task CreateOrUpdateStandard(StandardEditDto input);

        void DeleteStandard(EntityDto<long> input);
    }
}
