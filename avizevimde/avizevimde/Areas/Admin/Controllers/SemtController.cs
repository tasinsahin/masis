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
    public class SemtController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Semt/

        public ActionResult Index()
        {
            return View(db.semts.ToList());
        }

        //
        // GET: /Admin/Semt/Details/5

        public ActionResult Details(int id = 0)
        {
            semt semt = db.semts.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            return View(semt);
        }

        //
        // GET: /Admin/Semt/Create

        public ActionResult Create()
        {
            ViewBag.ilceId = new SelectList(db.ilces, "Id", "ilceAdi");
            return View();
        }

        //
        // POST: /Admin/Semt/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(semt semt)
        {
            if (ModelState.IsValid)
            {
                semt.eklenmeTarihi = System.DateTime.Now;
                semt.ekleyenId = WebSecurity.CurrentUserId;
                db.semts.Add(semt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semt);
        }

        //
        // GET: /Admin/Semt/Edit/5

        public ActionResult Edit(int id = 0)
        {
            semt semt = db.semts.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            return View(semt);
        }

        //
        // POST: /Admin/Semt/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(semt semt)
        {
            if (ModelState.IsValid)
            {
                semt.degistirmeTarihi = System.DateTime.Now;
                db.Entry(semt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semt);
        }

        //
        // GET: /Admin/Semt/Delete/5

        public ActionResult Delete(int id = 0)
        {
            semt semt = db.semts.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            return View(semt);
        }

        //
        // POST: /Admin/Semt/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            semt semt = db.semts.Find(id);
            db.semts.Remove(semt);
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