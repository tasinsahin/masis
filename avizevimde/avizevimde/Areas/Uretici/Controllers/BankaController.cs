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
    public class BankaController : avizevimde.Areas.Uretici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Uretici/UreticiBanka/

        public ActionResult Index()
        {
            return View(db.ureticiBankas.Where(f => f.ureticiId == WebSecurity.CurrentUserId).Select(f => f.ureticiId).Distinct().ToList());
        }

        //
        // GET: /Uretici/UreticiBanka/Details/5

        public ActionResult Details(int id = 0)
        {
            ureticiBanka ureticibanka = db.ureticiBankas.Find(id);
            if (ureticibanka == null)
            {
                return HttpNotFound();
            }
            return View(ureticibanka);
        }

        //
        // GET: /Uretici/UreticiBanka/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Uretici/UreticiBanka/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ureticiBanka ureticibanka)
        {
            if (ModelState.IsValid)
            {
                ureticibanka.eklenmeTarihi = System.DateTime.Now;
                db.ureticiBankas.Add(ureticibanka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ureticibanka);
        }

        //
        // GET: /Uretici/UreticiBanka/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ureticiBanka ureticibanka = db.ureticiBankas.Find(id);
            if (ureticibanka == null)
            {
                return HttpNotFound();
            }
            return View(ureticibanka);
        }

        //
        // POST: /Uretici/UreticiBanka/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ureticiBanka ureticibanka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ureticibanka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ureticibanka);
        }

        //
        // GET: /Uretici/UreticiBanka/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ureticiBanka ureticibanka = db.ureticiBankas.Find(id);
            if (ureticibanka == null)
            {
                return HttpNotFound();
            }
            return View(ureticibanka);
        }

        //
        // POST: /Uretici/UreticiBanka/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ureticiBanka ureticibanka = db.ureticiBankas.Find(id);
            db.ureticiBankas.Remove(ureticibanka);
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