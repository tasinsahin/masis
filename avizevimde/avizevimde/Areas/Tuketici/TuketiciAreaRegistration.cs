using System.Web.Mvc;

namespace avizevimde.Areas.Tuketici
{
    public class TuketiciAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Tuketici";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Tuketici_default",
                "Tuketici/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
