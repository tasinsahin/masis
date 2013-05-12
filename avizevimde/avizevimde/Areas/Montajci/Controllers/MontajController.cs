using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Montajci.Controllers
{
    public class MontajController : Controller
    {
        //
        // GET: /Montajci/Montaj/
        public ActionResult YapilacakIs()
        {
            return View();
        }
        public ActionResult Yapildi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yapildi(avizevimde.Areas.Admin.Models.montaj montaj)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("", "");
            }
            return View();
        }
        public ActionResult MontajSorunBildir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MontajSorunBildir(avizevimde.Areas.Tuketici.Models.montajSorun montajSorun)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("","");
            }
            return View();
        }
    }
}
