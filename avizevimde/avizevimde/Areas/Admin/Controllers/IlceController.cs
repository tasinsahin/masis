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
    public class IlceController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Ilce/

        public ActionResult Index()
        {
            var ilces = db.ilces.Include(i => i.sehir);
            return View(ilces.ToList());
        }

        //
        // GET: /Admin/Ilce/Details/5

        public ActionResult Details(int id = 0)
        {
            ilce ilce = db.ilces.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        //
        // GET: /Admin/Ilce/Create

        public ActionResult Create()
        {
            ViewBag.sehirId = new SelectList(db.sehirs, "Id", "sehirAdi");
            return View();
        }

        //
        // POST: /Admin/Ilce/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ilce ilce)
        {
            if (ModelState.IsValid)
            {
                ilce.eklenmeTarihi = System.DateTime.Now;
                ilce.ekleyenId = WebSecurity.CurrentUserId;
                db.ilces.Add(ilce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sehirId = new SelectList(db.sehirs, "Id", "sehirAdi", ilce.sehirId);
            return View(ilce);
        }

        //
        // GET: /Admin/Ilce/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ilce ilce = db.ilces.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            ViewBag.sehirId = new SelectList(db.sehirs, "Id", "sehirAdi", ilce.sehirId);
            return View(ilce);
        }

        //
        // POST: /Admin/Ilce/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ilce ilce)
        {
            if (ModelState.IsValid)
            {
                ilce.degistirmeTarihi = System.DateTime.Now;
                ilce.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(ilce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sehirId = new SelectList(db.sehirs, "Id", "sehirAdi", ilce.sehirId);
            return View(ilce);
        }

        //
        // GET: /Admin/Ilce/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ilce ilce = db.ilces.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        //
        // POST: /Admin/Ilce/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ilce ilce = db.ilces.Find(id);
            db.ilces.Remove(ilce);
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