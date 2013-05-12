using System;
using System.Collections.Generic; 
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Admin.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System.Data;
using WebMatrix.WebData;

namespace avizevimde.Areas.Admin.Controllers
{
    public class TasimaSartiController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/TasimaSarti/

        public ActionResult Index()
        {
            return View(db.tasimaSartis.ToList());
        }

        //
        // GET: /Admin/TasimaSarti/Details/5

        public ActionResult Details(int id = 0)
        {
            tasimaSarti tasimasarti = db.tasimaSartis.Find(id);
            if (tasimasarti == null)
            {
                return HttpNotFound();
            }
            return View(tasimasarti);
        }

        //
        // GET: /Admin/TasimaSarti/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/TasimaSarti/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tasimaSarti tasimasarti)
        {
            if (ModelState.IsValid)
            {
                tasimasarti.eklenmeTarihi = System.DateTime.Now;
                tasimasarti.ekleyenId = WebSecurity.CurrentUserId;
                db.tasimaSartis.Add(tasimasarti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tasimasarti);
        }

        //
        // GET: /Admin/TasimaSarti/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tasimaSarti tasimasarti = db.tasimaSartis.Find(id);
            if (tasimasarti == null)
            {
                return HttpNotFound();
            }
            return View(tasimasarti);
        }

        //
        // POST: /Admin/TasimaSarti/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tasimaSarti tasimasarti)
        {
            if (ModelState.IsValid)
            {
                tasimasarti.degistirmeTarihi = System.DateTime.Now;
                tasimasarti.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(tasimasarti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasimasarti);
        }

        //
        // GET: /Admin/TasimaSarti/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tasimaSarti tasimasarti = db.tasimaSartis.Find(id);
            if (tasimasarti == null)
            {
                return HttpNotFound();
            }
            return View(tasimasarti);
        }

        //
        // POST: /Admin/TasimaSarti/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tasimaSarti tasimasarti = db.tasimaSartis.Find(id);
            db.tasimaSartis.Remove(tasimasarti);
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