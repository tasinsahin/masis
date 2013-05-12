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
    public class TasiyiciSubeController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/TasiyiciSube/

        public ActionResult Index()
        {
            return View(db.tasiyiciSubes.ToList());
        }

        //
        // GET: /Admin/TasiyiciSube/Details/5

        public ActionResult Details(int id = 0)
        {
            tasiyiciSube tasiyicisube = db.tasiyiciSubes.Find(id);
            if (tasiyicisube == null)
            {
                return HttpNotFound();
            }
            return View(tasiyicisube);
        }

        //
        // GET: /Admin/TasiyiciSube/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/TasiyiciSube/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tasiyiciSube tasiyicisube)
        {
            if (ModelState.IsValid)
            {
                tasiyicisube.eklenmeTarihi = System.DateTime.Now;
                tasiyicisube.ekleyenId = WebSecurity.CurrentUserId;
                db.tasiyiciSubes.Add(tasiyicisube);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tasiyicisube);
        }

        //
        // GET: /Admin/TasiyiciSube/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tasiyiciSube tasiyicisube = db.tasiyiciSubes.Find(id);
            if (tasiyicisube == null)
            {
                return HttpNotFound();
            }
            return View(tasiyicisube);
        }

        //
        // POST: /Admin/TasiyiciSube/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tasiyiciSube tasiyicisube)
        {
            if (ModelState.IsValid)
            {
                tasiyicisube.degistirmeTarihi = System.DateTime.Now;
                tasiyicisube.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(tasiyicisube).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasiyicisube);
        }

        //
        // GET: /Admin/TasiyiciSube/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tasiyiciSube tasiyicisube = db.tasiyiciSubes.Find(id);
            if (tasiyicisube == null)
            {
                return HttpNotFound();
            }
            return View(tasiyicisube);
        }

        //
        // POST: /Admin/TasiyiciSube/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tasiyiciSube tasiyicisube = db.tasiyiciSubes.Find(id);
            db.tasiyiciSubes.Remove(tasiyicisube);
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