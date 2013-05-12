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
    public class StoktaOlursaController : Controller
    {
        private Models_ db = new Models_();

        //
        // GET: /Tuketici/StoktaOlursa/

        public ActionResult Index()
        {
            var stoktaolursas = db.stoktaOlursas.Where(f=>f.tuketiciId==WebSecurity.CurrentUserId).Include(s => s.urun);
            return View(stoktaolursas.ToList());
        }

        //
        // GET: /Tuketici/StoktaOlursa/Details/5

        public ActionResult Details(int id = 0)
        {
            stoktaOlursa stoktaolursa = db.stoktaOlursas.Find(id);
            if (stoktaolursa == null)
            {
                return HttpNotFound();
            }
            return View(stoktaolursa);
        }

        //
        // GET: /Tuketici/StoktaOlursa/Create

        public ActionResult Create()
        {
            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt");
            return View();
        }

        //
        // POST: /Tuketici/StoktaOlursa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(stoktaOlursa stoktaolursa)
        {
            if (ModelState.IsValid)
            {
                stoktaolursa.tuketiciId = WebSecurity.CurrentUserId;
                stoktaolursa.eklenmeTarihi = DateTime.Now;
                db.stoktaOlursas.Add(stoktaolursa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt", stoktaolursa.urunId);
            return View(stoktaolursa);
        }

        //
        // GET: /Tuketici/StoktaOlursa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            stoktaOlursa stoktaolursa = db.stoktaOlursas.Find(id);
            if (stoktaolursa == null)
            {
                return HttpNotFound();
            }
            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt", stoktaolursa.urunId);
            return View(stoktaolursa);
        }

        //
        // POST: /Tuketici/StoktaOlursa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(stoktaOlursa stoktaolursa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stoktaolursa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.urunId = new SelectList(db.uruns, "Id", "alt", stoktaolursa.urunId);
            return View(stoktaolursa);
        }

        //
        // GET: /Tuketici/StoktaOlursa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            stoktaOlursa stoktaolursa = db.stoktaOlursas.Find(id);
            if (stoktaolursa == null)
            {
                return HttpNotFound();
            }
            return View(stoktaolursa);
        }

        //
        // POST: /Tuketici/StoktaOlursa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stoktaOlursa stoktaolursa = db.stoktaOlursas.Find(id);
            db.stoktaOlursas.Remove(stoktaolursa);
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