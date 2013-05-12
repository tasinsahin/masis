using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using avizevimde.Areas.Admin.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin; 

namespace avizevimde.Areas.Admin.Controllers
{
    public class LogController : avizevimde.Areas.Admin.Controllers.AccountController
    {
        private Models_ db = new Models_();

        //
        // GET: /Admin/Log/

        public ActionResult Index()
        {
            var adminlogs = db.adminLogs.Include(a => a.admin);
            return View(adminlogs.ToList());
        }

        //
        // GET: /Admin/Log/Details/5

        public ActionResult Details(int id = 0)
        {
            adminLog adminlog = db.adminLogs.Find(id);
            if (adminlog == null)
            {
                return HttpNotFound();
            }
            return View(adminlog);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}