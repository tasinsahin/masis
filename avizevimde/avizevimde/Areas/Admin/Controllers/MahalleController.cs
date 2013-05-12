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
    public class MahalleController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

   
        //
        // GET: /Admin/Mahalle/
         
        public ActionResult Index()
        { 
            return View( db.ilces.ToList());
        }

        //
        // GET: /Admin/Mahalle/Details/5

        public ActionResult Details(int id = 0)
        {
            mahalle mahalle = db.mahalles.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        //
        // GET: /Admin/Mahalle/Create

        public ActionResult Create()
        {
            ViewBag.ilceId = new SelectList(db.ilces, "Id", "ilceAdi");
            return View();
        }

        //
        // POST: /Admin/Mahalle/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                mahalle.eklenmeTarihi = System.DateTime.Now;
                mahalle.ekleyenId = WebSecurity.CurrentUserId;
                db.mahalles.Add(mahalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ilceId = new SelectList(db.ilces, "Id", "ilceAdi", mahalle.ilceId);
            return View(mahalle);
        }

        //
        // GET: /Admin/Mahalle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            mahalle mahalle = db.mahalles.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ilceId = new SelectList(db.ilces, "Id", "ilceAdi", mahalle.ilceId);
            return View(mahalle);
        }

        //
        // POST: /Admin/Mahalle/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                mahalle.degistirmeTarihi = System.DateTime.Now;
                mahalle.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(mahalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ilceId = new SelectList(db.ilces, "Id", "ilceAdi", mahalle.ilceId);
            return View(mahalle);
        }

        //
        // GET: /Admin/Mahalle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            mahalle mahalle = db.mahalles.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        //
        // POST: /Admin/Mahalle/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mahalle mahalle = db.mahalles.Find(id);
            db.mahalles.Remove(mahalle);
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