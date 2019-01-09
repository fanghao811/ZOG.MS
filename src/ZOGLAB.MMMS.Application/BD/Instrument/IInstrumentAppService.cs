using Abp.Application.Services;
using System.Collections.Generic;

namespace ZOGLAB.MMMS.BD
{
    public interface IInstrumentAppService : IApplicationService
    {
        //Task<PagedResultDto<InstrumentListDto>> GetInstruments(GetUnitsInput input);
        List<InstrumentFReadDto> GetAll();
    }
}
