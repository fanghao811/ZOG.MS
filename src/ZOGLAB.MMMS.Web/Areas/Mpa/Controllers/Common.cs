using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using ZOGLAB.MMMS.Web.Areas.Mpa.Models.Common.Modals;
using ZOGLAB.MMMS.Web.Controllers;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class CommonController : MMMSControllerBase
    {
        public PartialViewResult LookupModal(LookupModalViewModel model)
        {
            return PartialView("Modals/_LookupModal", model);
        }
    }
}