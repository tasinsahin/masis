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
    public class TaksitController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Taksit/

        public ActionResult Index()
        {
            return View(db.taksits.ToList());
        }

        //
        // GET: /Admin/Taksit/Details/5

        public ActionResult Details(int id = 0)
        {
            taksit taksit = db.taksits.Find(id);
            if (taksit == null)
            {
                return HttpNotFound();
            }
            return View(taksit);
        }

        //
        // GET: /Admin/Taksit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Taksit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(taksit taksit)
        {
            if (ModelState.IsValid)
            {
                taksit.eklenmeTarihi = System.DateTime.Now;
                taksit.ekleyenId = WebSecurity.CurrentUserId;
                db.taksits.Add(taksit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taksit);
        }

        //
        // GET: /Admin/Taksit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            taksit taksit = db.taksits.Find(id);
            if (taksit == null)
            {
                return HttpNotFound();
            }
            return View(taksit);
        }

        //
        // POST: /Admin/Taksit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(taksit taksit)
        {
            if (ModelState.IsValid)
            {
                taksit.degistirmeTarihi = System.DateTime.Now;
                taksit.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(taksit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taksit);
        }

        //
        // GET: /Admin/Taksit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            taksit taksit = db.taksits.Find(id);
            if (taksit == null)
            {
                return HttpNotFound();
            }
            return View(taksit);
        }

        //
        // POST: /Admin/Taksit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taksit taksit = db.taksits.Find(id);
            db.taksits.Remove(taksit);
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