using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Admin.Controllers
{
    public class MontajController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        //
        // GET: /Admin/Montaj/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MontajciAta()
        {
            return View();
        }
        public ActionResult Sorunlar()
        {
            return View();
        }
    }
}
