using Abp.WebApi.Controllers;

namespace ZOGLAB.MMMS.WebApi
{
    public abstract class MMMSApiControllerBase : AbpApiController
    {
        protected MMMSApiControllerBase()
        {
            LocalizationSourceName = MMMSConsts.LocalizationSourceName;
        }
    }
}