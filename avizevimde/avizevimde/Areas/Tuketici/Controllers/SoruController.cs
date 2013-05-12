using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Tuketici.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class SoruController : Controller
    {
        private Models_ db = new Models_();

        //
        // GET: /Tuketici/Soru/

        public ActionResult Index()
        {
            var sorus = db.sorus.Include(s => s.tuketici);
            return View(sorus.ToList());
        }

        //
        // GET: /Tuketici/Soru/Details/5

        public ActionResult Details(int id = 0)
        {
            soru soru = db.sorus.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            return View(soru);
        }

        //
        // GET: /Tuketici/Soru/Create

        public ActionResult Create()
        {
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi");
            return View();
        }

        //
        // POST: /Tuketici/Soru/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(soru soru)
        {
            if (ModelState.IsValid)
            {
                db.sorus.Add(soru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", soru.tuketiciId);
            return View(soru);
        }

        //
        // GET: /Tuketici/Soru/Edit/5

        public ActionResult Edit(int id = 0)
        {
            soru soru = db.sorus.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", soru.tuketiciId);
            return View(soru);
        }

        //
        // POST: /Tuketici/Soru/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(soru soru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", soru.tuketiciId);
            return View(soru);
        }

        //
        // GET: /Tuketici/Soru/Delete/5

        public ActionResult Delete(int id = 0)
        {
            soru soru = db.sorus.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            return View(soru);
        }

        //
        // POST: /Tuketici/Soru/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            soru soru = db.sorus.Find(id);
            db.sorus.Remove(soru);
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