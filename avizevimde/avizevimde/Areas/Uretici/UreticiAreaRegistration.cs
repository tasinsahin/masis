using System.Web.Mvc;

namespace avizevimde.Areas.Uretici
{
    public class UreticiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Uretici";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Uretici_default",
                "Uretici/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }

    }
}
