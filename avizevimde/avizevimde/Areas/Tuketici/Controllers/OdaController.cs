using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.ComponentModel.DataAnnotations;
using avizevimde.Areas.Tuketici.Models;
using System.Data;
using avizevimde.Filters;
using WebMatrix.WebData;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class OdaController : avizevimde.Areas.Tuketici.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Tuketici/Oda/

        public ActionResult Index()
        {
            return View(db.odas.ToList());
        }

        //
        // GET: /Tuketici/Oda/Details/5

        public ActionResult Details(int id = 0)
        {
            oda oda = db.odas.Find(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        //
        // GET: /Tuketici/Oda/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tuketici/Oda/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(oda oda)
        {
            if (ModelState.IsValid)
            {
                oda.tuketiciId = WebSecurity.CurrentUserId;
                oda.eklenmeTarihi = System.DateTime.Now;
                db.odas.Add(oda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oda);
        }

        //
        // GET: /Tuketici/Oda/Edit/5

        public ActionResult Edit(int id = 0)
        {            
            oda oda = db.odas.Find(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        //
        // POST: /Tuketici/Oda/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(oda oda)
        {
            if (ModelState.IsValid)
            {
                oda.degistirmeTarihi = System.DateTime.Now;
                db.Entry(oda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oda);
        }

        //
        // GET: /Tuketici/Oda/Delete/5

        public ActionResult Delete(int id = 0)
        {
            oda oda = db.odas.Find(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        //
        // POST: /Tuketici/Oda/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oda oda = db.odas.Find(id);
            db.odas.Remove(oda);
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