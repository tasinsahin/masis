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
    public class Urun2Controller : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Uretici/Urun2/

        public ActionResult Index()
        {
            return View(db.urun2s.ToList());
        }

        //
        // GET: /Uretici/Urun2/Details/5

        public ActionResult Details(int id = 0)
        {
            urun2 urun2 = db.urun2s.Find(id);
            if (urun2 == null)
            {
                return HttpNotFound();
            }
            return View(urun2);
        }

        //
        // GET: /Uretici/Urun2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Uretici/Urun2/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(avizevimde.Areas.Admin.Models.urun2 urun2)
        {
            if (ModelState.IsValid)
            {
                urun2.eklenmeTarihi = System.DateTime.Now;
                db.urun2s.Add(urun2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urun2);
        }

        //
        // GET: /Uretici/Urun2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            urun2 urun2 = db.urun2s.Find(id);
            if (urun2 == null)
            {
                return HttpNotFound();
            }
            return View(urun2);
        }

        //
        // POST: /Uretici/Urun2/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(avizevimde.Areas.Admin.Models.urun2 urun2)
        {
            if (ModelState.IsValid)
            {
                urun2.degistirmeTarihi = System.DateTime.Now;
                db.Entry(urun2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urun2);
        }

        //
        // GET: /Uretici/Urun2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            urun2 urun2 = db.urun2s.Find(id);
            if (urun2 == null)
            {
                return HttpNotFound();
            }
            return View(urun2);
        }

        //
        // POST: /Uretici/Urun2/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            urun2 urun2 = db.urun2s.Find(id);
            db.urun2s.Remove(urun2);
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