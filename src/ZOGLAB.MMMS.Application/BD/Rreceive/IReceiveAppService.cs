using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IReceiveAppService : IApplicationService
    {
        //Task<PagedResultDto<UnitListDto>> GetUnits(GetUnitsInput input);
        Task<List<BD_Receive>> GetAll();
        Task CreateOrUpdateReveice(ReceiveEditDto input);
        void DeleteItem(EntityDto<long> input);
        Task AddInstrumentToReceive(long instrumentId, long receiveId);
        Task RemoveInstrumentFromReceive(long instrumentId, long receiveId);
    }
}
