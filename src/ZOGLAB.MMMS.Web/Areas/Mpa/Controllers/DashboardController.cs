using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using ZOGLAB.MMMS.Authorization;
using ZOGLAB.MMMS.Web.Controllers;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : MMMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}