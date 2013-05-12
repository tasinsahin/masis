using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class MontajController : Controller
    {
        //
        // GET: /Tuketici/Montaj/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult MontajYapildi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MontajYapildi(avizevimde.Areas.Admin.Models.montaj  montaj)
        {
            return View();
        }
        public ActionResult MontajSorunBildir()
        {
            return View();
        }
        public ActionResult MontajSorunBildir(avizevimde.Areas.Tuketici.Models.montajSorun montajSorun)
        {
            return View();
        }
    }
}
