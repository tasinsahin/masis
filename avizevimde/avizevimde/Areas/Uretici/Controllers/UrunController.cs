using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;
using avizevimde.Areas.Admin.Models;

namespace avizevimde.Areas.Uretici.Controllers
{
    public class UrunController : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Uretici/Urun/

        public ActionResult Index()
        {
            var uruns = db.uruns;
            return View(uruns.ToList());
        }

        //
        // GET: /Uretici/Urun/Details/5

        public ActionResult Details(int id = 0)
        {
            urun urun = db.uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        //
        // GET: /Uretici/Urun/Create

        public ActionResult Create()
        {
            ViewBag.vergiId = new SelectList(db.vergis, "Id", "Id");
            ViewBag.taksitId = new SelectList(db.taksits, "taksitSecenegiId", "kartAdi");
            ViewBag.markaId = new SelectList(db.markas, "Id", "tanim");
            ViewBag.renkId = new SelectList(db.renks, "Id", "adi");
            ViewBag.kategoriId = new SelectList(db.kategoris, "Id", "aciklama");
            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi");
            return View();
        }

        //
        // POST: /Uretici/Urun/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(avizevimde.Areas.Admin.Models.urun urun)
        {
            if (ModelState.IsValid)
            {
                urun.eklenmeTarihi = System.DateTime.Now;
                db.uruns.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vergiId = new SelectList(db.vergis, "Id", "Id", urun.vergiId);
            ViewBag.taksitId = new SelectList(db.taksits, "taksitSecenegiId", "kartAdi", urun.taksitId);
            ViewBag.markaId = new SelectList(db.markas, "Id", "tanim", urun.markaId);
             ViewBag.kategoriId = new SelectList(db.kategoris, "Id", "aciklama", urun.kategoriId);
            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi", urun.ureticiId);
            return View(urun);
        }

        //
        // GET: /Uretici/Urun/Edit/5

        public ActionResult Edit(int id = 0)
        {
            urun urun = db.uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.vergiId = new SelectList(db.vergis, "Id", "Id", urun.vergiId);
            ViewBag.taksitId = new SelectList(db.taksits, "taksitSecenegiId", "kartAdi", urun.taksitId);
            ViewBag.markaId = new SelectList(db.markas, "Id", "tanim", urun.markaId);
             ViewBag.kategoriId = new SelectList(db.kategoris, "Id", "aciklama", urun.kategoriId);
            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi", urun.ureticiId);
            return View(urun);
        }

        //
        // POST: /Uretici/Urun/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(avizevimde.Areas.Admin.Models.urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vergiId = new SelectList(db.vergis, "Id", "Id", urun.vergiId);
            ViewBag.taksitId = new SelectList(db.taksits, "taksitSecenegiId", "kartAdi", urun.taksitId);
            ViewBag.markaId = new SelectList(db.markas, "Id", "tanim", urun.markaId);
             ViewBag.kategoriId = new SelectList(db.kategoris, "Id", "aciklama", urun.kategoriId);
            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi", urun.ureticiId);
            return View(urun);
        }

        //
        // GET: /Uretici/Urun/Delete/5

        public ActionResult Delete(int id = 0)
        {
            urun urun = db.uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        //
        // POST: /Uretici/Urun/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            urun urun = db.uruns.Find(id);
            db.uruns.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}