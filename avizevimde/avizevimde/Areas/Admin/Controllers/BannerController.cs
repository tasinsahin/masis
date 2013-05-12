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

namespace avizevimde.Areas.Admin.Controller
{
    public class BannerController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Banner/

        public ActionResult Index()
        {
            return View(db.banners.ToList());
        }

        //
        // GET: /Admin/Banner/Details/5

        public ActionResult Details(int id = 0)
        {
            banner banner = db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        //
        // GET: /Admin/Banner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Banner/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(banner banner)
        {
            if (ModelState.IsValid)
            {
                banner.eklenmeTarihi = System.DateTime.Now;
                banner.ekleyenId = WebSecurity.CurrentUserId;
                db.banners.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        //
        // GET: /Admin/Banner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            banner banner = db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        //
        // POST: /Admin/Banner/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(banner banner)
        {
            if (ModelState.IsValid)
            {
                banner.degistirmeTarihi = System.DateTime.Now;
                banner.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);
        }

        //
        // GET: /Admin/Banner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            banner banner = db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        //
        // POST: /Admin/Banner/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            banner banner = db.banners.Find(id);
            db.banners.Remove(banner);
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