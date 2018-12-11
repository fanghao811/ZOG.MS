using Abp.Domain.Services;

namespace ZOGLAB.MMMS
{
    public abstract class MMMSDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected MMMSDomainServiceBase()
        {
            LocalizationSourceName = MMMSConsts.LocalizationSourceName;
        }
    }
}
