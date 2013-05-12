using System.Web.Mvc;

namespace avizevimde.Areas.KisitliAdmin
{
    public class KisitliAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "KisitliAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "KisitliAdmin_default",
                "KisitliAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
