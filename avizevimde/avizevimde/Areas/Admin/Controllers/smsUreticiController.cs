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
    public class smsUreticiController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/smsUretici/

        public ActionResult Index()
        {
            var smsureticis = db.smsUreticis.Include(s => s.ekleyen);
            return View(smsureticis.ToList());
        }

        //
        // GET: /Admin/smsUretici/Details/5

        public ActionResult Details(int id = 0)
        {
            smsUretici smsuretici = db.smsUreticis.Find(id);
            if (smsuretici == null)
            {
                return HttpNotFound();
            }
            return View(smsuretici);
        }

        //
        // GET: /Admin/smsUretici/Create

        public ActionResult Create()
        {
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminName");
            ViewBag.ekleyenId = new SelectList(db.UserProfiles, "Id", "adminName");
            return View();
        }

        //
        // POST: /Admin/smsUretici/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(smsUretici smsuretici)
        {
            if (ModelState.IsValid)
            {
                smsuretici.eklenmeTarihi = System.DateTime.Now;
                smsuretici.ekleyenId = WebSecurity.CurrentUserId;
                db.smsUreticis.Add(smsuretici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ekleyenId = new SelectList(db.UserProfiles, "Id", "adminName", smsuretici.ekleyen); 
            return View(smsuretici);
        }


        //
        // GET: /Admin/smsUretici/Delete/5

        public ActionResult Delete(int id = 0)
        {
            smsUretici smsuretici = db.smsUreticis.Find(id);
            if (smsuretici == null)
            {
                return HttpNotFound();
            }
            return View(smsuretici);
        }

        //
        // POST: /Admin/smsUretici/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            smsUretici smsuretici = db.smsUreticis.Find(id);
            db.smsUreticis.Remove(smsuretici);
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