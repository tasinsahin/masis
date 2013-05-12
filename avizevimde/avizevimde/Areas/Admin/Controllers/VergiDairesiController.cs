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
    public class VergiDairesiController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/VergiDairesi/

        public ActionResult Index()
        {
            return View(db.vergiDairesis.ToList());
        }

        //
        // GET: /Admin/VergiDairesi/Details/5

        public ActionResult Details(int id = 0)
        {
            vergiDairesi vergidairesi = db.vergiDairesis.Find(id);
            if (vergidairesi == null)
            {
                return HttpNotFound();
            }
            return View(vergidairesi);
        }

        //
        // GET: /Admin/VergiDairesi/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/VergiDairesi/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vergiDairesi vergidairesi)
        {
            if (ModelState.IsValid)
            {
                vergidairesi.eklenmeTarihi = System.DateTime.Now;
                db.vergiDairesis.Add(vergidairesi);
                vergidairesi.ekleyenId = WebSecurity.CurrentUserId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vergidairesi);
        }

        //
        // GET: /Admin/VergiDairesi/Edit/5

        public ActionResult Edit(int id = 0)
        {
            vergiDairesi vergidairesi = db.vergiDairesis.Find(id);
            if (vergidairesi == null)
            {
                return HttpNotFound();
            }
            return View(vergidairesi);
        }

        //
        // POST: /Admin/VergiDairesi/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vergiDairesi vergidairesi)
        {
            if (ModelState.IsValid)
            {
                vergidairesi.degistirmeTarihi = System.DateTime.Now;
                db.Entry(vergidairesi).State = EntityState.Modified;
                vergidairesi.degistirenId = WebSecurity.CurrentUserId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vergidairesi);
        }

        //
        // GET: /Admin/VergiDairesi/Delete/5

        public ActionResult Delete(int id = 0)
        {
            vergiDairesi vergidairesi = db.vergiDairesis.Find(id);
            if (vergidairesi == null)
            {
                return HttpNotFound();
            }
            return View(vergidairesi);
        }

        //
        // POST: /Admin/VergiDairesi/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vergiDairesi vergidairesi = db.vergiDairesis.Find(id);
            db.vergiDairesis.Remove(vergidairesi);
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