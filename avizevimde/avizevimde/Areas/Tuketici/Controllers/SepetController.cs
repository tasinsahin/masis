using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using avizevimde.Areas.Tuketici.Models;
using System.Data;
using WebMatrix.WebData;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class SepetController : avizevimde.Areas.Tuketici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Tuketici/Sepet/

        public ActionResult Index()
        {
            var sepets = db.sepets.Include(s => s.tuketici).Include(s => s.oda);
            return View(sepets.ToList());
        }

        //
        // GET: /Tuketici/Sepet/Details/5

        public ActionResult Details(int id = 0)
        {
            sepet sepet = db.sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            return View(sepet);
        }

        //
        // GET: /Tuketici/Sepet/Create

        public ActionResult Create()
        {
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi");
            ViewBag.tuketiciOdaId = new SelectList(db.odas, "Id", "resim");
            return View();
        }

        //
        // POST: /Tuketici/Sepet/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sepet sepet)
        {
            if (ModelState.IsValid)
            {
                sepet.tuketiciId = WebSecurity.CurrentUserId;
                sepet.eklenmeTarihi = System.DateTime.Now;
                db.sepets.Add(sepet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", sepet.tuketiciId);
            ViewBag.tuketiciOdaId = new SelectList(db.odas, "Id", "resim", sepet.odaId);
            return View(sepet);
        }

        //
        // GET: /Tuketici/Sepet/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sepet sepet = db.sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", sepet.tuketiciId);
            ViewBag.tuketiciOdaId = new SelectList(db.odas, "Id", "resim", sepet.odaId);
            return View(sepet);
        }

        //
        // POST: /Tuketici/Sepet/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sepet sepet)
        {
            if (ModelState.IsValid)
            {
                sepet.degistirmeTarihi = System.DateTime.Now;
                db.Entry(sepet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", sepet.tuketiciId);
            ViewBag.tuketiciOdaId = new SelectList(db.odas, "Id", "resim", sepet.odaId);
            return View(sepet);
        }

        //
        // GET: /Tuketici/Sepet/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sepet sepet = db.sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            return View(sepet);
        }

        //
        // POST: /Tuketici/Sepet/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sepet sepet = db.sepets.Find(id);
            db.sepets.Remove(sepet);
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