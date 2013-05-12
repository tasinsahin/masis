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
    public class MarkaController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Marka/

        public ActionResult Index()
        {
            var markas = db.markas.Include(m => m.ekleyen);
            return View(markas.ToList());
        }

        //
        // GET: /Admin/Marka/Details/5

        public ActionResult Details(int id = 0)
        {
            marka marka = db.markas.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        //
        // GET: /Admin/Marka/Create

        public ActionResult Create()
        {
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi");
            return View();
        }

        //
        // POST: /Admin/Marka/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(marka marka)
        {
            if (ModelState.IsValid)
            {
                marka.eklenmeTarihi = System.DateTime.Now;
                marka.ekleyenId = WebSecurity.CurrentUserId;
                db.markas.Add(marka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi", marka.degistirenId);
            return View(marka);
        }

        //
        // GET: /Admin/Marka/Edit/5

        public ActionResult Edit(int id = 0)
        {
            marka marka = db.markas.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi", marka.degistirenId);
            return View(marka);
        }

        //
        // POST: /Admin/Marka/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(marka marka)
        {
            if (ModelState.IsValid)
            {
                marka.degistirmeTarihi = System.DateTime.Now;
                marka.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(marka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminAdi", marka.degistirenId);
            return View(marka);
        }

        //
        // GET: /Admin/Marka/Delete/5

        public ActionResult Delete(int id = 0)
        {
            marka marka = db.markas.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        //
        // POST: /Admin/Marka/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            marka marka = db.markas.Find(id);
            db.markas.Remove(marka);
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