using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Admin.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using WebMatrix.WebData;

namespace avizevimde.Areas.Admin.Controllers
{
    public class smsTuketiciController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/smsTuketici/

        public ActionResult Index()
        {
            var smstuketicis = db.smsTuketicis.Include(s => s.ekleyen);
            return View(smstuketicis.ToList());
        }

        //
        // GET: /Admin/smsTuketici/Details/5

        public ActionResult Details(int id = 0)
        {
            smsTuketici smstuketici = db.smsTuketicis.Find(id);
            if (smstuketici == null)
            {
                return HttpNotFound();
            }
            return View(smstuketici);
        }

        //
        // GET: /Admin/smsTuketici/Create

        public ActionResult Create()
        {
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminName");
            ViewBag.ekleyenId = new SelectList(db.UserProfiles, "Id", "adminName");
            return View();
        }

        //
        // POST: /Admin/smsTuketici/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(smsTuketici smstuketici)
        {
            if (ModelState.IsValid)
            {
                smstuketici.eklenmeTarihi = System.DateTime.Now;
                smstuketici.ekleyenId = WebSecurity.CurrentUserId;
                db.smsTuketicis.Add(smstuketici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminName", smstuketici.degistirenId); 
            return View(smstuketici);
        }


        //
        // GET: /Admin/smsTuketici/Delete/5

        public ActionResult Delete(int id = 0)
        {
            smsTuketici smstuketici = db.smsTuketicis.Find(id);
            if (smstuketici == null)
            {
                return HttpNotFound();
            }
            return View(smstuketici);
        }

        //
        // POST: /Admin/smsTuketici/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            smsTuketici smstuketici = db.smsTuketicis.Find(id);
            db.smsTuketicis.Remove(smstuketici);
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