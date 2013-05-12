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
    public class BankaController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Banka/

        public ActionResult Index()
        {
            return View(db.bankas.ToList());
        }

        //
        // GET: /Admin/Banka/Details/5

        public ActionResult Details(int id = 0)
        {
            banka banka = db.bankas.Find(id);
            if (banka == null)
            {
                return HttpNotFound();
            }
            return View(banka);
        }

        //
        // GET: /Admin/Banka/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Banka/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(banka banka)
        {
            if (ModelState.IsValid)
            {
                banka.eklenmeTarihi = System.DateTime.Now;
                banka.ekleyenId = WebSecurity.CurrentUserId;
                db.bankas.Add(banka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banka);
        }

        //
        // GET: /Admin/Banka/Edit/5

        public ActionResult Edit(int id = 0)
        {
            
            banka banka = db.bankas.Find(id);
            if (banka == null)
            {
                return HttpNotFound();
            }
            return View(banka);
        }

        //
        // POST: /Admin/Banka/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(banka banka)
        {
            if (ModelState.IsValid)
            {
                banka.degistirmeTarihi = System.DateTime.Now;
                banka.degistirenId = WebSecurity.CurrentUserId;
                db.Entry(banka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banka);
        }

        //
        // GET: /Admin/Banka/Delete/5

        public ActionResult Delete(int id = 0)
        {
            banka banka = db.bankas.Find(id);
            if (banka == null)
            {
                return HttpNotFound();
            }
            return View(banka);
        }

        //
        // POST: /Admin/Banka/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            banka banka = db.bankas.Find(id);
            db.bankas.Remove(banka);
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