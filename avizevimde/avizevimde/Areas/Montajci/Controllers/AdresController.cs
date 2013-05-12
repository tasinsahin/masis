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
using avizevimde.Filters;

namespace avizevimde.Areas.Montajci.Controllers
{
    public class AdresController : avizevimde.Areas.Montajci.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Montajci/MontajciAdres/

        public ActionResult Index()
        {
            return View(db.MontajciAdres.Where(f => f.montajciId == WebSecurity.CurrentUserId).Select(f => f.montajciId).Distinct().ToList());
        }

        //
        // GET: /Montajci/MontajciAdres/Details/5

        public ActionResult Details(int id = 0)
        {
            MontajciAdres montajciadres = db.MontajciAdres.Find(id);
            if (montajciadres == null)
            {
                return HttpNotFound();
            }
            return View(montajciadres);
        }

        //
        // GET: /Montajci/MontajciAdres/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Montajci/MontajciAdres/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MontajciAdres montajciadres)
        {
            if (ModelState.IsValid)
            {
                montajciadres.EklenmeTarihi = System.DateTime.Now;
                db.MontajciAdres.Add(montajciadres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(montajciadres);
        }

        //
        // GET: /Montajci/MontajciAdres/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MontajciAdres montajciadres = db.MontajciAdres.Find(id);
            if (montajciadres == null)
            {
                return HttpNotFound();
            }
            return View(montajciadres);
        }

        //
        // POST: /Montajci/MontajciAdres/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MontajciAdres montajciadres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(montajciadres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(montajciadres);
        }

        //
        // GET: /Montajci/MontajciAdres/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MontajciAdres montajciadres = db.MontajciAdres.Find(id);
            if (montajciadres == null)
            {
                return HttpNotFound();
            }
            return View(montajciadres);
        }

        //
        // POST: /Montajci/MontajciAdres/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MontajciAdres montajciadres = db.MontajciAdres.Find(id);
            db.MontajciAdres.Remove(montajciadres);
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