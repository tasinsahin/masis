using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Admin.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;
using WebMatrix.WebData;

namespace avizevimde.Areas.Admin.Controllers
{
    public class RenkController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Renk/

        public ActionResult Index()
        {
            var renks = db.renks.Include(r => r.degistirenId);
            return View(renks.ToList());
        }

        //
        // GET: /Admin/Renk/Details/5

        public ActionResult Details(int id = 0)
        {
            renk renk = db.renks.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        //
        // GET: /Admin/Renk/Create

        public ActionResult Create()
        {
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi");
            return View();
        }

        //
        // POST: /Admin/Renk/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(renk renk)
        {
            if (ModelState.IsValid)
            {
                renk.eklenmeTarihi = System.DateTime.Now;
                renk.ekleyenId = WebSecurity.CurrentUserId;
                db.renks.Add(renk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi", renk.degistirmeTarihi);
            return View(renk);
        }

        //
        // GET: /Admin/Renk/Edit/5

        public ActionResult Edit(int id = 0)
        {
            renk renk = db.renks.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        //
        // POST: /Admin/Renk/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(renk renk)
        {
            if (ModelState.IsValid)
            {
                renk.degistirmeTarihi = System.DateTime.Now;
                renk.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(renk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ekleyenId = new SelectList(db.UserProfiles, "Id", "adminAdi", renk.degistirenId);
            return View(renk);
        }

        //
        // GET: /Admin/Renk/Delete/5

        public ActionResult Delete(int id = 0)
        {
            renk renk = db.renks.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        //
        // POST: /Admin/Renk/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            renk renk = db.renks.Find(id);
            db.renks.Remove(renk);
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