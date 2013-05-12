using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using avizevimde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Controllers
{
    public class HomeController : Controller
    {
        private Models_ db = new Models_();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UyeGirisi()
        {
            return View();
        }
        public ActionResult UyeOl()
        {
            return View();
        }
        public ActionResult Yardim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yardim(yardim yardim)
        {
            if (ModelState.IsValid)
            {
                yardim.eklenmeTarihi = DateTime.Now;
                db.yardims.Add(yardim);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Iletisim(oneri oneri)
        {
            if (ModelState.IsValid)
            {
                oneri.eklenmeTarihi = DateTime.Now;
                db.oneris.Add(oneri);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult GelismisArama()
        {
            return View();
        }
        public ActionResult Sepet()
        {
            return View();
        }
        public ActionResult GizlilikPolitikasi()
        {
            return View();
        }
        public ActionResult KullanimKosullari()
        {
            return View();
        }
        public ActionResult DavetEt()
        {
            return View();
        }
        public ActionResult SiparisAdimBir()
        {
            return View();
        }
        public ActionResult SiparisAdimIki()
        {
            return View();
        }
    }
}
