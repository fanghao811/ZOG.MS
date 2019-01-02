using Abp.Application.Services;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IBinaryAppService : IApplicationService
    {
        string GetBinaryForTest();
        Task<string> SaveImages();
    }
}
