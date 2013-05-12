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
    public class FaturaController : avizevimde.Areas.Montajci.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Montajci/MontajciFatura/

        public ActionResult Index()
        {
            return View(db.MontajciFaturas.Where(f=>f.montajciId==WebSecurity.CurrentUserId).Select(f=>f.montajciId).Distinct().ToList());
        }

        //
        // GET: /Montajci/MontajciFatura/Details/5

        public ActionResult Details(int id = 0)
        {
            MontajciFatura montajcifatura = db.MontajciFaturas.Find(id);
            if (montajcifatura == null)
            {
                return HttpNotFound();
            }
            return View(montajcifatura);
        }

        //
        // GET: /Montajci/MontajciFatura/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Montajci/MontajciFatura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MontajciFatura montajcifatura)
        {
            if (ModelState.IsValid)
            {
                montajcifatura.eklenmeTarihi = System.DateTime.Now;
                db.MontajciFaturas.Add(montajcifatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(montajcifatura);
        }

        //
        // GET: /Montajci/MontajciFatura/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MontajciFatura montajcifatura = db.MontajciFaturas.Find(id);
            if (montajcifatura == null)
            {
                return HttpNotFound();
            }
            return View(montajcifatura);
        }

        //
        // POST: /Montajci/MontajciFatura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MontajciFatura montajcifatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(montajcifatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(montajcifatura);
        }

        //
        // GET: /Montajci/MontajciFatura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MontajciFatura montajcifatura = db.MontajciFaturas.Find(id);
            if (montajcifatura == null)
            {
                return HttpNotFound();
            }
            return View(montajcifatura);
        }

        //
        // POST: /Montajci/MontajciFatura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MontajciFatura montajcifatura = db.MontajciFaturas.Find(id);
            db.MontajciFaturas.Remove(montajcifatura);
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