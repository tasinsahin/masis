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
    public class BankaSubeController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/BankaSube/

        public ActionResult Index()
        {
            return View(db.bankaSubes.ToList());
        }

        //
        // GET: /Admin/BankaSube/Details/5

        public ActionResult Details(int id = 0)
        {
            bankaSube bankasube = db.bankaSubes.Find(id);
            if (bankasube == null)
            {
                return HttpNotFound();
            }
            return View(bankasube);
        }

        //
        // GET: /Admin/BankaSube/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/BankaSube/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(bankaSube bankasube)
        {
            if (ModelState.IsValid)
            {
                bankasube.eklenmeTarihi = System.DateTime.Now;
                bankasube.ekleyenId = WebSecurity.CurrentUserId;
                db.bankaSubes.Add(bankasube);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankasube);
        }

        //
        // GET: /Admin/BankaSube/Edit/5

        public ActionResult Edit(int id = 0)
        {
            bankaSube bankasube = db.bankaSubes.Find(id);
            if (bankasube == null)
            {
                return HttpNotFound();
            }
            return View(bankasube);
        }

        //
        // POST: /Admin/BankaSube/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(bankaSube bankasube)
        {
            if (ModelState.IsValid)
            {
                bankasube.degistirmeTarihi = System.DateTime.Now;
                bankasube.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(bankasube).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankasube);
        }

        //
        // GET: /Admin/BankaSube/Delete/5

        public ActionResult Delete(int id = 0)
        {
            bankaSube bankasube = db.bankaSubes.Find(id);
            if (bankasube == null)
            {
                return HttpNotFound();
            }
            return View(bankasube);
        }

        //
        // POST: /Admin/BankaSube/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bankaSube bankasube = db.bankaSubes.Find(id);
            db.bankaSubes.Remove(bankasube);
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