using System;
using System.Collections.Generic;
using System.Data.Entity; 
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Uretici.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;

namespace avizevimde.Areas.Uretici.Controllers
{
    public class UreticiController : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Uretici/Uretici/

        public ActionResult Index()
        {
            return View(db.ureticis.ToList());
        }

        //
        // GET: /Uretici/Uretici/Details/5

        public ActionResult Details(int id = 0)
        {
            uretici uretici = db.ureticis.Find(id);
            if (uretici == null)
            {
                return HttpNotFound();
            }
            return View(uretici);
        }

        //
        // GET: /Uretici/Uretici/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Uretici/Uretici/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(uretici uretici)
        {
            if (ModelState.IsValid)
            {
                uretici.eklenmeTarihi=  System.DateTime.Now;
                db.ureticis.Add(uretici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uretici);
        }

        //
        // GET: /Uretici/Uretici/Edit/5

        public ActionResult Edit(int id = 0)
        {
            uretici uretici = db.ureticis.Find(id);
            if (uretici == null)
            {
                return HttpNotFound();
            }
            return View(uretici);
        }

        //
        // POST: /Uretici/Uretici/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uretici uretici)
        {
            if (ModelState.IsValid)
            {
                uretici.degistirmeTarihi = System.DateTime.Now;
                db.Entry(uretici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uretici);
        }

        //
        // GET: /Uretici/Uretici/Delete/5

        public ActionResult Delete(int id = 0)
        {
            uretici uretici = db.ureticis.Find(id);
            if (uretici == null)
            {
                return HttpNotFound();
            }
            return View(uretici);
        }

        //
        // POST: /Uretici/Uretici/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uretici uretici = db.ureticis.Find(id);
            db.ureticis.Remove(uretici);
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