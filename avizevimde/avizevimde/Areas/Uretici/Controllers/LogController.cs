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
    public class LogController : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Uretici/UreticiLog/

        public ActionResult Index()
        {
            var ureticilogs = db.ureticiLogs.Include(u => u.uretici);
            return View(ureticilogs.ToList());
        }

        //
        // GET: /Uretici/UreticiLog/Details/5

        public ActionResult Details(int id = 0)
        {
            ureticiLog ureticilog = db.ureticiLogs.Find(id);
            if (ureticilog == null)
            {
                return HttpNotFound();
            }
            return View(ureticilog);
        }

        //
        // GET: /Uretici/UreticiLog/Create

        public ActionResult Create()
        {
            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi");
            return View();
        }

        //
        // POST: /Uretici/UreticiLog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ureticiLog ureticilog)
        {
            if (ModelState.IsValid)
            {
                ureticilog.eklenmeTarihi = System.DateTime.Now;
                db.ureticiLogs.Add(ureticilog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi", ureticilog.ureticiId);
            return View(ureticilog);
        }

        //
        // GET: /Uretici/UreticiLog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ureticiLog ureticilog = db.ureticiLogs.Find(id);
            if (ureticilog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi", ureticilog.ureticiId);
            return View(ureticilog);
        }

        //
        // POST: /Uretici/UreticiLog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ureticiLog ureticilog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ureticilog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ureticiId = new SelectList(db.ureticis, "id", "ureticiAdi", ureticilog.ureticiId);
            return View(ureticilog);
        }

        //
        // GET: /Uretici/UreticiLog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ureticiLog ureticilog = db.ureticiLogs.Find(id);
            if (ureticilog == null)
            {
                return HttpNotFound();
            }
            return View(ureticilog);
        }

        //
        // POST: /Uretici/UreticiLog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ureticiLog ureticilog = db.ureticiLogs.Find(id);
            db.ureticiLogs.Remove(ureticilog);
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