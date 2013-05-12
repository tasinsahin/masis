using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Tuketici.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using WebMatrix.WebData;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class FiyatDuserseController : Controller
    {
        private Models_ db = new Models_();

        //
        // GET: /Tuketici/FiyatDuserse/

        public ActionResult Index()
        {
            var fiyatduserses = db.fiyatDuserses.Where(f=>f.tuketiciId==WebSecurity.CurrentUserId).Include(f => f.urun);
            return View(fiyatduserses.ToList());
        }

        //
        // GET: /Tuketici/FiyatDuserse/Details/5

        public ActionResult Details(int id = 0)
        {
            fiyatDuserse fiyatduserse = db.fiyatDuserses.Find(id);
            if (fiyatduserse == null)
            {
                return HttpNotFound();
            }
            return View(fiyatduserse);
        }

        //
        // GET: /Tuketici/FiyatDuserse/Create

        public ActionResult Create()
        {
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi");
            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt");
            return View();
        }

        //
        // POST: /Tuketici/FiyatDuserse/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fiyatDuserse fiyatduserse)
        {
            if (ModelState.IsValid)
            {
                fiyatduserse.tuketiciId = WebSecurity.CurrentUserId;
                fiyatduserse.eklenmeTarihi = DateTime.Now;
                db.fiyatDuserses.Add(fiyatduserse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt", fiyatduserse.urunId);
            return View(fiyatduserse);
        }

        //
        // GET: /Tuketici/FiyatDuserse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fiyatDuserse fiyatduserse = db.fiyatDuserses.Find(id);
            if (fiyatduserse == null)
            {
                return HttpNotFound();
            }
            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt", fiyatduserse.urunId);
            return View(fiyatduserse);
        }

        //
        // POST: /Tuketici/FiyatDuserse/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(fiyatDuserse fiyatduserse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiyatduserse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt", fiyatduserse.urunId);
            return View(fiyatduserse);
        }

        //
        // GET: /Tuketici/FiyatDuserse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fiyatDuserse fiyatduserse = db.fiyatDuserses.Find(id);
            if (fiyatduserse == null)
            {
                return HttpNotFound();
            }
            return View(fiyatduserse);
        }

        //
        // POST: /Tuketici/FiyatDuserse/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fiyatDuserse fiyatduserse = db.fiyatDuserses.Find(id);
            db.fiyatDuserses.Remove(fiyatduserse);
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