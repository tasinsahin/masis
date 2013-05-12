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
    public class BlogController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Blog/

        public ActionResult Index()
        {
            return View(db.blogs.ToList());
        }

        //
        // GET: /Admin/Blog/Details/5

        public ActionResult Details(int id = 0)
        {
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // GET: /Admin/Blog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Blog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.eklenmeTarihi = System.DateTime.Now;
                blog.ekleyenId = WebSecurity.CurrentUserId;
                db.blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        //
        // GET: /Admin/Blog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Admin/Blog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                blog.degistirenId = WebSecurity.CurrentUserId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        //
        // GET: /Admin/Blog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                blog.degistirmeTarihi = System.DateTime.Now;
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Admin/Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            blog blog = db.blogs.Find(id);
            db.blogs.Remove(blog);
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