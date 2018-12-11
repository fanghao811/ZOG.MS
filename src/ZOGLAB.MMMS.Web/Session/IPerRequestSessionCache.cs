using System.Threading.Tasks;
using ZOGLAB.MMMS.Sessions.Dto;

namespace ZOGLAB.MMMS.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
