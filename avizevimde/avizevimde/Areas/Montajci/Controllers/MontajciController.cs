﻿using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Montajci.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;

namespace avizevimde.Areas.Montajci.Controllers
{
    public class MontajciController : avizevimde.Areas.Montajci.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Montajci/Montajci/

        public ActionResult Index()
        {
            return View(db.montajcis.ToList());
        }

        //
        // GET: /Montajci/Montajci/Details/5

        public ActionResult Details(int id = 0)
        {
            montajci montajci = db.montajcis.Find(id);
            if (montajci == null)
            {
                return HttpNotFound();
            }
            return View(montajci);
        }

        //
        // GET: /Montajci/Montajci/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Montajci/Montajci/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(montajci montajci)
        {
            if (ModelState.IsValid)
            {
                montajci.eklenmeTarihi = System.DateTime.Now;
                db.montajcis.Add(montajci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(montajci);
        }

        //
        // GET: /Montajci/Montajci/Edit/5

        public ActionResult Edit(int id = 0)
        {
            montajci montajci = db.montajcis.Find(id);
            if (montajci == null)
            {
                return HttpNotFound();
            }
            return View(montajci);
        }

        //
        // POST: /Montajci/Montajci/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(montajci montajci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(montajci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(montajci);
        }

        //
        // GET: /Montajci/Montajci/Delete/5

        public ActionResult Delete(int id = 0)
        {
            montajci montajci = db.montajcis.Find(id);
            if (montajci == null)
            {
                return HttpNotFound();
            }
            return View(montajci);
        }

        //
        // POST: /Montajci/Montajci/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            montajci montajci = db.montajcis.Find(id);
            db.montajcis.Remove(montajci);
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