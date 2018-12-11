using Abp.Dependency;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Views;

namespace ZOGLAB.MMMS.Web.Views
{
    public abstract class MMMSWebViewPageBase : MMMSWebViewPageBase<dynamic>
    {
       
    }

    public abstract class MMMSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public IAbpSession AbpSession { get; private set; }
        
        protected MMMSWebViewPageBase()
        {
            AbpSession = IocManager.Instance.Resolve<IAbpSession>();
            LocalizationSourceName = MMMSConsts.LocalizationSourceName;
        }
    }
}