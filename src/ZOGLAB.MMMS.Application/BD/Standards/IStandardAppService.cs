using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IStandardAppService: IApplicationService
    {
        Task<PagedResultDto<StandardListDto>> GetStandards(GetStandardsInput input);

        //Task<GetStandardForEditOutput> GetStandardForEdit(NullableIdDto input);

        //Task CreateOrUpdateStandard(CreateOrUpdateStandardInput input);

        //Task DeleteStandard(EntityDto input);
    }
}
