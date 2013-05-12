using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Montajci.Controllers
{
    public class LogController : avizevimde.Areas.Montajci.Controllers.AccountController
    {
        //
        // GET: /Montajci/Log/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }


    }
}
