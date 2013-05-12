using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.Montajci.Controllers
{
    public class MuzayedeController : avizevimde.Areas.Montajci.Controllers.AccountController
    {
        //
        // GET: /Montajci/MontajciSiparis/
        avizevimde.avizeevimdeDB__avizevimde.Areas.Admin.Models_ db = new avizevimde.avizeevimdeDB__avizevimde.Areas.Admin.Models_();
        public ActionResult Index()
        {
            var muzayedes = db.muzayedes.ToList();
            return View(muzayedes);
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult TeklifGor()
        {
            return View();
        }
        public ActionResult TeklifVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TeklifVer(avizevimde.Areas.Admin.Models.muzayedeTeklif muzayedeTeklif)
        {
            if (ModelState.IsValid)
            {
                RedirectToAction("", "");
            }
            return View(muzayedeTeklif);
        }
    }
}
