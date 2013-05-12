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
    public class KategoriController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Kategori/

        public ActionResult Index()
        {
            return View(db.kategoris.ToList());
        }

        //
        // GET: /Admin/Kategori/Details/5

        public ActionResult Details(int id = 0)
        {
            kategori kategori = db.kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // GET: /Admin/Kategori/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Kategori/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.eklenmeTarihi = System.DateTime.Now;
                kategori.ekleyenId = WebSecurity.CurrentUserId;
                db.kategoris.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        //
        // GET: /Admin/Kategori/Edit/5

        public ActionResult Edit(int id = 0)
        {
            kategori kategori = db.kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // POST: /Admin/Kategori/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.degistirmeTarihi = System.DateTime.Now;
                kategori.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        //
        // GET: /Admin/Kategori/Delete/5

        public ActionResult Delete(int id = 0)
        {
            kategori kategori = db.kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // POST: /Admin/Kategori/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kategori kategori = db.kategoris.Find(id);
            db.kategoris.Remove(kategori);
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