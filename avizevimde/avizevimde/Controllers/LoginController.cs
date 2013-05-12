using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            var area = returnUrl.TrimStart('/').Split('/').FirstOrDefault();

            if (!string.IsNullOrEmpty(area))
            {
                return RedirectToAction("Login", "Account", new { area });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            // TODO: Handle what happens if no area was accessed.
        }     
    }
}
