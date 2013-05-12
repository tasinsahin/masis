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
    public class AdresController : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Uretici/UreticiAdres/

        public ActionResult Index()
        {
            return View(db.ureticiAress.Where(f => f.ureticiId == WebSecurity.CurrentUserId).Select(f => f.ureticiId).Distinct().ToList());
        }

        //
        // GET: /Uretici/UreticiAdres/Details/5

        public ActionResult Details(int id = 0)
        {
            ureticiAdres ureticiadres = db.ureticiAress.Find(id);
            if (ureticiadres == null)
            {
                return HttpNotFound();
            }
            return View(ureticiadres);
        }

        //
        // GET: /Uretici/UreticiAdres/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Uretici/UreticiAdres/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ureticiAdres ureticiadres)
        {
            if (ModelState.IsValid)
            {
                ureticiadres.EklenmeTarihi = System.DateTime.Now;
                db.ureticiAress.Add(ureticiadres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ureticiadres);
        }

        //
        // GET: /Uretici/UreticiAdres/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ureticiAdres ureticiadres = db.ureticiAress.Find(id);
            if (ureticiadres == null)
            {
                return HttpNotFound();
            }
            return View(ureticiadres);
        }

        //
        // POST: /Uretici/UreticiAdres/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ureticiAdres ureticiadres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ureticiadres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ureticiadres);
        }

        //
        // GET: /Uretici/UreticiAdres/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ureticiAdres ureticiadres = db.ureticiAress.Find(id);
            if (ureticiadres == null)
            {
                return HttpNotFound();
            }
            return View(ureticiadres);
        }

        //
        // POST: /Uretici/UreticiAdres/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ureticiAdres ureticiadres = db.ureticiAress.Find(id);
            db.ureticiAress.Remove(ureticiadres);
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