using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using ZOGLAB.MMMS.Authorization;
using ZOGLAB.MMMS.Web.Controllers;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : MMMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}