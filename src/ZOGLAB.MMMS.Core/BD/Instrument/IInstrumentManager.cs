using Abp.Domain.Services;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IInstrumentManager : IDomainService
    {
        Task AddToReceiveAsync(long instrumentId, long receiveId);
        Task AddToReceiveAsync(BD_Instrument instrument, BD_Receive receive);
        Task RemoveFromReceiveAsync(long instrumentId, long receiveId);
        Task RemoveFromReceiveAsync(BD_Instrument instrument, BD_Receive receive);
    }
}
