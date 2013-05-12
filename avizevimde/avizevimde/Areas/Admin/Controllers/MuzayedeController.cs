using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Admin.Controllers
{
    public class MuzayedeController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        //
        // GET: /Admin/AdminMuzayede/

        public ActionResult Index()
        {
            return View();
        }

    }
}
