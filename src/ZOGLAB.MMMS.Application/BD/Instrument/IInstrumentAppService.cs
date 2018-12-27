using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IInstrumentAppService : IApplicationService
    {
        //Task<PagedResultDto<InstrumentListDto>> GetInstruments(GetUnitsInput input);
        List<InstrumentFReadDto> GetAll();
    }
}
