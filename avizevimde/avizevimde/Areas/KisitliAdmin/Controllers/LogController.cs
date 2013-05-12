using avizevimde.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avizevimde.Areas.KisitliAdmin.Controllers
{
    public class LogController : Controller
    {
        private avizevimde.avizeevimdeDB__avizevimde.Areas.Admin.Models_ db = new avizevimde.avizeevimdeDB__avizevimde.Areas.Admin.Models_();

        //
        // GET: /Admin/Log/

        public ActionResult Index()
        {
            var kisitliAdminLogs = db.kisitliAdminLogs;
            return View(kisitliAdminLogs.ToList());
        }

        //
        // GET: /Admin/Log/Details/5

        public ActionResult Details(int id = 0)
        {
            kisitliAdminLog kisitliAdminLog = db.kisitliAdminLogs.Find(id);
            if (kisitliAdminLog == null)
            {
                return HttpNotFound();
            }
            return View(kisitliAdminLog);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
