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
    public class BankaController : avizevimde.Areas.Tuketici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /TuketiciBanka/

        public ActionResult Index()
        {
            return View(db.tuketiciBankas.Where(f => f.tuketiciId == WebSecurity.CurrentUserId).Select(f => f.tuketiciId).Distinct().ToList());
        }

        //
        // GET: /TuketiciBanka/Details/5

        public ActionResult Details(int id = 0)
        {
            tuketiciBanka tuketicibanka = db.tuketiciBankas.Find(id);
            if (tuketicibanka == null)
            {
                return HttpNotFound();
            }
            return View(tuketicibanka);
        }

        //
        // GET: /TuketiciBanka/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TuketiciBanka/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tuketiciBanka tuketicibanka)
        {
            if (ModelState.IsValid)
            {
                tuketicibanka.eklenmeTarihi = System.DateTime.Now;
                db.tuketiciBankas.Add(tuketicibanka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuketicibanka);
        }

        //
        // GET: /TuketiciBanka/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tuketiciBanka tuketicibanka = db.tuketiciBankas.Find(id);
            if (tuketicibanka == null)
            {
                return HttpNotFound();
            }
            return View(tuketicibanka);
        }

        //
        // POST: /TuketiciBanka/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tuketiciBanka tuketicibanka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuketicibanka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuketicibanka);
        }

        //
        // GET: /TuketiciBanka/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tuketiciBanka tuketicibanka = db.tuketiciBankas.Find(id);
            if (tuketicibanka == null)
            {
                return HttpNotFound();
            }
            return View(tuketicibanka);
        }

        //
        // POST: /TuketiciBanka/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tuketiciBanka tuketicibanka = db.tuketiciBankas.Find(id);
            db.tuketiciBankas.Remove(tuketicibanka);
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