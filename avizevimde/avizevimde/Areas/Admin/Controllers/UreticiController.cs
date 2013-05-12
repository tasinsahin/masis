using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Uretici.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;

namespace avizevimde.Areas.Admin.Controllers
{
    public class UreticiController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/AdminUretici/

        public ActionResult Index()
        {
            return View(db.ureticis.ToList());
        }

        //
        // GET: /Admin/AdminUretici/Details/5

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
        // GET: /Admin/AdminUretici/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/AdminUretici/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(uretici uretici)
        {
            if (ModelState.IsValid)
            {
                uretici.eklenmeTarihi = DateTime.Now;
                db.ureticis.Add(uretici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uretici);
        }

        //
        // GET: /Admin/AdminUretici/Edit/5

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
        // POST: /Admin/AdminUretici/Edit/5

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
        // GET: /Admin/AdminUretici/Delete/5

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
        // POST: /Admin/AdminUretici/Delete/5

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