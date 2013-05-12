using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using avizevimde.Areas.Admin.Models;
using System.Data;
using WebMatrix.WebData;

namespace avizevimde.Areas.Admin.Controllers
{
    public class LogoController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Logo/

        public ActionResult Index()
        {
            var logos = db.logos.Include(l => l.ekleyen);
            return View(logos.ToList());
        }

        //
        // GET: /Admin/Logo/Details/5

        public ActionResult Details(int id = 0)
        {
            logo logo = db.logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        //
        // GET: /Admin/Logo/Create

        public ActionResult Create()
        {
            ViewBag.ekleyenId = new SelectList(db.UserProfiles, "Id", "adminAdi");
            return View();
        }

        //
        // POST: /Admin/Logo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(logo logo)
        {
            if (ModelState.IsValid)
            {
                logo.eklenmeTarihi = System.DateTime.Now;
                logo.ekleyenId = WebSecurity.CurrentUserId;
                db.logos.Add(logo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi", logo.degistirenId);
            return View(logo);
        }

        //
        // GET: /Admin/Logo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            logo logo = db.logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi", logo.degistirenId);
            return View(logo);
        }

        //
        // POST: /Admin/Logo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(logo logo)
        {
            if (ModelState.IsValid)
            {
                logo.degistirmeTarihi = System.DateTime.Now;
                logo.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(logo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi", logo.degistirenId);
            return View(logo);
        }

        //
        // GET: /Admin/Logo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            logo logo = db.logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        //
        // POST: /Admin/Logo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            logo logo = db.logos.Find(id);
            db.logos.Remove(logo);
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