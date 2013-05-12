using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class SiparisController : avizevimde.Areas.Tuketici.Controllers.AccountController
    {
        //
        // GET: /Tuketici/TuketiciSiparis/

        public ActionResult SiparisOlustur()
        {
            return View();
        }
        public ActionResult SiparisGor()
        {
            return View();
        }
        public ActionResult SiparisGeldi()
        {
            return View();
        }
        public ActionResult SiparisSorunBildir()
        {
            return View();
        }

    }
}
