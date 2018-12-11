using Abp.Authorization;
using ZOGLAB.MMMS.Authorization.Roles;
using ZOGLAB.MMMS.Authorization.Users;
using ZOGLAB.MMMS.MultiTenancy;

namespace ZOGLAB.MMMS.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
