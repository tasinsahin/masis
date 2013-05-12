using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Montajci.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;
using WebMatrix.WebData;

namespace avizevimde.Areas.Montajci.Controllers
{
    public class BankaController : avizevimde.Areas.Montajci.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Montajci/MontajciBanka/

        public ActionResult Index()
        {
            return View(db.MontajciBankas.Where(f => f.montajciId == WebSecurity.CurrentUserId).Select(f => f.montajciId).Distinct().ToList());
        }

        //
        // GET: /Montajci/MontajciBanka/Details/5

        public ActionResult Details(int id = 0)
        {
            MontajciBanka montajcibanka = db.MontajciBankas.Find(id);
            if (montajcibanka == null)
            {
                return HttpNotFound();
            }
            return View(montajcibanka);
        }

        //
        // GET: /Montajci/MontajciBanka/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Montajci/MontajciBanka/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MontajciBanka montajcibanka)
        {
            if (ModelState.IsValid)
            {
                montajcibanka.eklenmeTarihi = System.DateTime.Now;
                db.MontajciBankas.Add(montajcibanka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(montajcibanka);
        }

        //
        // GET: /Montajci/MontajciBanka/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MontajciBanka montajcibanka = db.MontajciBankas.Find(id);
            if (montajcibanka == null)
            {
                return HttpNotFound();
            }
            return View(montajcibanka);
        }

        //
        // POST: /Montajci/MontajciBanka/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MontajciBanka montajcibanka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(montajcibanka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(montajcibanka);
        }

        //
        // GET: /Montajci/MontajciBanka/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MontajciBanka montajcibanka = db.MontajciBankas.Find(id);
            if (montajcibanka == null)
            {
                return HttpNotFound();
            }
            return View(montajcibanka);
        }

        //
        // POST: /Montajci/MontajciBanka/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MontajciBanka montajcibanka = db.MontajciBankas.Find(id);
            db.MontajciBankas.Remove(montajcibanka);
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