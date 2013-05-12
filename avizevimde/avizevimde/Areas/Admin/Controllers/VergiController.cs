using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Admin.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;

namespace avizevimde.Areas.Admin.Controllers
{
    public class VergiController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Vergi/

        public ActionResult Index()
        {
            var vergis = db.vergis;
            return View(vergis.ToList());
        }

        //
        // GET: /Admin/Vergi/Details/5

        public ActionResult Details(int id = 0)
        {
            vergi vergi = db.vergis.Find(id);
            if (vergi == null)
            {
                return HttpNotFound();
            }
            return View(vergi);
        }

        //
        // GET: /Admin/Vergi/Create

        public ActionResult Create()
        {
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi");
            return View();
        }

        //
        // POST: /Admin/Vergi/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vergi vergi)
        {
            if (ModelState.IsValid)
            {
                db.vergis.Add(vergi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
             
            return View(vergi);
        }

        //
        // GET: /Admin/Vergi/Edit/5

        public ActionResult Edit(int id = 0)
        {
            vergi vergi = db.vergis.Find(id);
            if (vergi == null)
            {
                return HttpNotFound();
            }
             return View(vergi);
        }

        //
        // POST: /Admin/Vergi/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vergi vergi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vergi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
             return View(vergi);
        }

        //
        // GET: /Admin/Vergi/Delete/5

        public ActionResult Delete(int id = 0)
        {
            vergi vergi = db.vergis.Find(id);
            if (vergi == null)
            {
                return HttpNotFound();
            }
            return View(vergi);
        }

        //
        // POST: /Admin/Vergi/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vergi vergi = db.vergis.Find(id);
            db.vergis.Remove(vergi);
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