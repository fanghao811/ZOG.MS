using System.Web.Mvc;
using Abp.Auditing;

namespace ZOGLAB.MMMS.Web.Controllers
{
    public class ErrorController : MMMSControllerBase
    {
        [DisableAuditing]
        public ActionResult E404()
        {
            return View();
        }
    }
}