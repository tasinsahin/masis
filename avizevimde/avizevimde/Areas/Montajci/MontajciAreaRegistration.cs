using System.Web.Mvc;

namespace avizevimde.Areas.Montajci
{
    public class MontajciAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Montajci";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Montajci_default",
                "Montajci/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
