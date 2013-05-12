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
    public class smsMontajciController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/smsMontajci/

        public ActionResult Index()
        {
            var smsmontajcis = db.smsMontajcis.Include(s => s.ekleyen);
            return View(smsmontajcis.ToList());
        }

        //
        // GET: /Admin/smsMontajci/Details/5

        public ActionResult Details(int id = 0)
        {
            smsMontajci smsmontajci = db.smsMontajcis.Find(id);
            if (smsmontajci == null)
            {
                return HttpNotFound();
            }
            return View(smsmontajci);
        }

        //
        // GET: /Admin/smsMontajci/Create

        public ActionResult Create()
        {
            ViewBag.degistirenId = new SelectList(db.UserProfiles, "Id", "adminName");
            ViewBag.ekleyenId = new SelectList(db.UserProfiles, "Id", "adminName");
            return View();
        }

        //
        // POST: /Admin/smsMontajci/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(smsMontajci smsmontajci)
        {
            if (ModelState.IsValid)
            {
                smsmontajci.eklenmeTarihi = System.DateTime.Now;
                smsmontajci.ekleyenId = WebSecurity.CurrentUserId;
                db.smsMontajcis.Add(smsmontajci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ekleyenId = new SelectList(db.UserProfiles, "Id", "adminName", smsmontajci.ekleyen);
            return View(smsmontajci);
        }


        //
        // GET: /Admin/smsMontajci/Delete/5

        public ActionResult Delete(int id = 0)
        {
            smsMontajci smsmontajci = db.smsMontajcis.Find(id);
            if (smsmontajci == null)
            {
                return HttpNotFound();
            }
            return View(smsmontajci);
        }

        //
        // POST: /Admin/smsMontajci/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            smsMontajci smsmontajci = db.smsMontajcis.Find(id);
            db.smsMontajcis.Remove(smsmontajci);
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