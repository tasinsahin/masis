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
    public class SehirController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Sehir/

        public ActionResult Index()
        {
            var sehirs = db.sehirs.Include(i => i.ekleyen).Include(i=>i.degistiren);

            return View(sehirs.ToList());
        }

        //
        // GET: /Admin/Sehir/Details/5

        public ActionResult Details(int id = 0)
        {
            sehir sehir = db.sehirs.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        //
        // GET: /Admin/Sehir/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Sehir/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sehir sehir)
        {
            if (ModelState.IsValid)
            {
                sehir.eklenmeTarihi =Convert.ToDateTime(DateTime.Now);
                sehir.ekleyenId = WebSecurity.CurrentUserId; 
                db.sehirs.Add(sehir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sehir);
        }

        //
        // GET: /Admin/Sehir/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sehir sehir = db.sehirs.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        //
        // POST: /Admin/Sehir/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sehir sehir)
        {
            if (ModelState.IsValid)
            {
                sehir.degistirmeTarihi = Convert.ToDateTime(DateTime.Now);
                sehir.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(sehir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sehir);
        }

        //
        // GET: /Admin/Sehir/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sehir sehir = db.sehirs.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        //
        // POST: /Admin/Sehir/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sehir sehir = db.sehirs.Find(id);
            db.sehirs.Remove(sehir);
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