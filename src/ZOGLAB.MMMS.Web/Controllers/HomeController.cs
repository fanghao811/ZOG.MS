using System.Web.Mvc;

namespace ZOGLAB.MMMS.Web.Controllers
{
    public class HomeController : MMMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}