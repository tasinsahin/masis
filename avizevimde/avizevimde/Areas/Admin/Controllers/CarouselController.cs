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
    public class CarouselController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Carousel/

        public ActionResult Index()
        {
            return View(db.carousels.ToList());
        }

        //
        // GET: /Admin/Carousel/Details/5

        public ActionResult Details(int id = 0)
        {
            carousel carousel = db.carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        //
        // GET: /Admin/Carousel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Carousel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(carousel carousel)
        {
            if (ModelState.IsValid)
            {
                carousel.eklenmeTarihi = System.DateTime.Now;
                carousel.ekleyenId = WebSecurity.CurrentUserId;
                db.carousels.Add(carousel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carousel);
        }

        //
        // GET: /Admin/Carousel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            carousel carousel = db.carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        //
        // POST: /Admin/Carousel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(carousel carousel)
        {
            if (ModelState.IsValid)
            {
                carousel.degistirmeTarihi = System.DateTime.Now;
                carousel.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(carousel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carousel);
        }

        //
        // GET: /Admin/Carousel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            carousel carousel = db.carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        //
        // POST: /Admin/Carousel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carousel carousel = db.carousels.Find(id);
            db.carousels.Remove(carousel);
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