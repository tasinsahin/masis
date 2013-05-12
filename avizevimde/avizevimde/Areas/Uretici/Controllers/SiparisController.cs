using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Uretici.Controllers
{
    public class SiparisController : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        //
        // GET: /Uretici/UreticiSiparis/

        public ActionResult Index()
        {
            return View();
        }

    }
}
