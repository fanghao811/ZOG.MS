using ZOGLAB.MMMS.Sessions.Dto;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Layout
{
    public class FooterViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public string GetProductNameWithEdition()
        {
            var productName = "MMMS";

            if (LoginInformations.Tenant != null && LoginInformations.Tenant.EditionDisplayName != null)
            {
                productName += " " + LoginInformations.Tenant.EditionDisplayName;
            }

            return productName;
        }
    }
}