using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Uretici.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;
using WebMatrix.WebData;

namespace avizevimde.Areas.Uretici.Controllers
{
    public class FaturaController : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Uretici/UreticiFatura/

        public ActionResult Index()
        {
            return View(db.ureticiFaturas.Where(f => f.ureticiId == WebSecurity.CurrentUserId).Select(f => f.ureticiId).Distinct().ToList());
        }

        //
        // GET: /Uretici/UreticiFatura/Details/5

        public ActionResult Details(int id = 0)
        {
            ureticiFatura ureticifatura = db.ureticiFaturas.Find(id);
            if (ureticifatura == null)
            {
                return HttpNotFound();
            }
            return View(ureticifatura);
        }

        //
        // GET: /Uretici/UreticiFatura/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Uretici/UreticiFatura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ureticiFatura ureticifatura)
        {
            if (ModelState.IsValid)
            {
                ureticifatura.eklenmeTarihi = System.DateTime.Now;
                db.ureticiFaturas.Add(ureticifatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ureticifatura);
        }

        //
        // GET: /Uretici/UreticiFatura/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ureticiFatura ureticifatura = db.ureticiFaturas.Find(id);
            if (ureticifatura == null)
            {
                return HttpNotFound();
            }
            return View(ureticifatura);
        }

        //
        // POST: /Uretici/UreticiFatura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ureticiFatura ureticifatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ureticifatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ureticifatura);
        }

        //
        // GET: /Uretici/UreticiFatura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ureticiFatura ureticifatura = db.ureticiFaturas.Find(id);
            if (ureticifatura == null)
            {
                return HttpNotFound();
            }
            return View(ureticifatura);
        }

        //
        // POST: /Uretici/UreticiFatura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ureticiFatura ureticifatura = db.ureticiFaturas.Find(id);
            db.ureticiFaturas.Remove(ureticifatura);
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