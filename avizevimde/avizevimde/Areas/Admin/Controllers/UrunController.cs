using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Admin.Controllers
{
    public class UrunController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        //
        // GET: /Admin/Urun/

        public ActionResult Index()
        {
            return View();
        }

    }
}
