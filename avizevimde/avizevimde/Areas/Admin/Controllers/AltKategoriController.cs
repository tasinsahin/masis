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
    public class AltKategoriController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/AltKategori/

        public ActionResult Index()
        {
            return View(db.altKategoris.ToList());
        }

        //
        // GET: /Admin/AltKategori/Details/5

        public ActionResult Details(int id = 0)
        {
            altKategori altkategori = db.altKategoris.Find(id);
            if (altkategori == null)
            {
                return HttpNotFound();
            }
            return View(altkategori);
        }

        //
        // GET: /Admin/AltKategori/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/AltKategori/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(altKategori altkategori)
        {
            if (ModelState.IsValid)
            {
                altkategori.eklenmeTarihi = System.DateTime.Now;
                altkategori.ekleyenId = WebSecurity.CurrentUserId;
                db.altKategoris.Add(altkategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(altkategori);
        }

        //
        // GET: /Admin/AltKategori/Edit/5

        public ActionResult Edit(int id = 0)
        {
            altKategori altkategori = db.altKategoris.Find(id);
            if (altkategori == null)
            {
                return HttpNotFound();
            }
            return View(altkategori);
        }

        //
        // POST: /Admin/AltKategori/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(altKategori altkategori)
        {
            if (ModelState.IsValid)
            {
                altkategori.degistirmeTarihi = System.DateTime.Now;
                altkategori.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(altkategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(altkategori);
        }

        //
        // GET: /Admin/AltKategori/Delete/5

        public ActionResult Delete(int id = 0)
        {
            altKategori altkategori = db.altKategoris.Find(id);
            if (altkategori == null)
            {
                return HttpNotFound();
            }
            return View(altkategori);
        }

        //
        // POST: /Admin/AltKategori/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            altKategori altkategori = db.altKategoris.Find(id);
            db.altKategoris.Remove(altkategori);
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