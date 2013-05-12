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
    public class FaturaController : avizevimde.Areas.Tuketici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /TuketiciFatura/

        public ActionResult Index()
        {            
            return View(db.tuketiciFaturas.Where(f => f.tuketiciId == WebSecurity.CurrentUserId).Select(f => f.tuketiciId).Distinct().ToList());
        }

        //
        // GET: /TuketiciFatura/Details/5

        public ActionResult Details(int id = 0)
        {
            tuketiciFatura tuketicifatura = db.tuketiciFaturas.Find(id);
            if (tuketicifatura == null)
            {
                return HttpNotFound();
            }
            return View(tuketicifatura);
        }

        //
        // GET: /TuketiciFatura/Create

        public ActionResult Create()
        {
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi");
            ViewBag.vergiDairesiId = new SelectList(db.vergiDairesis, "Id", "adi");
            return View();
        }

        //
        // POST: /TuketiciFatura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tuketiciFatura tuketicifatura)
        {
            if (ModelState.IsValid)
            {
                tuketicifatura.eklenmeTarihi = System.DateTime.Now;
                db.tuketiciFaturas.Add(tuketicifatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", tuketicifatura.tuketiciId);
            ViewBag.vergiDairesiId = new SelectList(db.vergiDairesis, "Id", "adi", tuketicifatura.vergiDairesiId);
            return View(tuketicifatura);
        }

        //
        // GET: /TuketiciFatura/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tuketiciFatura tuketicifatura = db.tuketiciFaturas.Find(id);
            if (tuketicifatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", tuketicifatura.tuketiciId);
            ViewBag.vergiDairesiId = new SelectList(db.vergiDairesis, "Id", "adi", tuketicifatura.vergiDairesiId);
            return View(tuketicifatura);
        }

        //
        // POST: /TuketiciFatura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tuketiciFatura tuketicifatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuketicifatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tuketiciId = new SelectList(db.tuketicis, "tuketiciId", "tuketiciAdi", tuketicifatura.tuketiciId);
            ViewBag.vergiDairesiId = new SelectList(db.vergiDairesis, "Id", "adi", tuketicifatura.vergiDairesiId);
            return View(tuketicifatura);
        }

        //
        // GET: /TuketiciFatura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tuketiciFatura tuketicifatura = db.tuketiciFaturas.Find(id);
            if (tuketicifatura == null)
            {
                return HttpNotFound();
            }
            return View(tuketicifatura);
        }

        //
        // POST: /TuketiciFatura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tuketiciFatura tuketicifatura = db.tuketiciFaturas.Find(id);
            db.tuketiciFaturas.Remove(tuketicifatura);
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