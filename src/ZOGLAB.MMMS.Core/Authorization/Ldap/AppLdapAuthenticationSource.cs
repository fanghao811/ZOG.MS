using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using ZOGLAB.MMMS.Authorization.Users;
using ZOGLAB.MMMS.MultiTenancy;

namespace ZOGLAB.MMMS.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
