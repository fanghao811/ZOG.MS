using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace ZOGLAB.MMMS.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
