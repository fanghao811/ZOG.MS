using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using ZOGLAB.MMMS.Web.Controllers;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : MMMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}