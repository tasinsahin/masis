using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using avizevimde.Areas.Tuketici.Models;
using System.Data;
using WebMatrix.WebData;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class AdresController : avizevimde.Areas.Tuketici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /TuketiciAdres/

        public ActionResult Index()
        {
            return View(db.tuketiciAdres.Where(f => f.tuketiciId == WebSecurity.CurrentUserId).Select(f => f.tuketiciId).Distinct().ToList());
        }

        //
        // GET: /TuketiciAdres/Details/5

        public ActionResult Details(int id = 0)
        {
            tuketiciAdres tuketiciadres = db.tuketiciAdres.Find(id);
            if (tuketiciadres == null)
            {
                return HttpNotFound();
            }
            return View(tuketiciadres);
        }

        //
        // GET: /TuketiciAdres/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TuketiciAdres/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tuketiciAdres tuketiciadres)
        {
            if (ModelState.IsValid)
            {
                tuketiciadres.EklenmeTarihi = System.DateTime.Now;
                db.tuketiciAdres.Add(tuketiciadres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuketiciadres);
        }

        //
        // GET: /TuketiciAdres/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tuketiciAdres tuketiciadres = db.tuketiciAdres.Find(id);
            if (tuketiciadres == null)
            {
                return HttpNotFound();
            }
            return View(tuketiciadres);
        }

        //
        // POST: /TuketiciAdres/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tuketiciAdres tuketiciadres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuketiciadres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuketiciadres);
        }

        //
        // GET: /TuketiciAdres/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tuketiciAdres tuketiciadres = db.tuketiciAdres.Find(id);
            if (tuketiciadres == null)
            {
                return HttpNotFound();
            }
            return View(tuketiciadres);
        }

        //
        // POST: /TuketiciAdres/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tuketiciAdres tuketiciadres = db.tuketiciAdres.Find(id);
            db.tuketiciAdres.Remove(tuketiciadres);
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