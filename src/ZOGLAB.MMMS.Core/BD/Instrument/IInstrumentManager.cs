using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IInstrumentManager : IDomainService
    {
        Task<List<BD_Receive>> GetReceivesAsync(BD_Instrument instrument);
        List<BD_Instrument> GetRegistedInstruments(BD_Receive receive);
        Task AddToReceiveAsync(long instrumentId, long receiveId);
        Task AddToReceiveAsync(BD_Instrument instrument, BD_Receive receive);
        Task RemoveFromReceiveAsync(long instrumentId, long receiveId);
        Task RemoveFromReceiveAsync(BD_Instrument instrument, BD_Receive receive);
    }
}
