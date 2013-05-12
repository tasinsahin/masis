using avizevimde.Areas.Admin.Models;
using avizevimde.Areas.Montajci.Models;
using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace avizevimde.Areas.Admin.Controllers
{
    public class IletiController : System.Web.Mvc.Controller
    {
        //
        // GET: /Admin/AdminIleti/

        Models_ db = new Models_();

        public ActionResult Index()
        {
            avizevimde.Areas.Admin.Models.IletiView IletiViews = new avizevimde.Areas.Admin.Models.IletiView();
            foreach (var item in db.montajciAdmineIletis)
            {
                if (item.Id == WebSecurity.CurrentUserId)
                {
                    montajciAdmineIleti montajciAdmineIleti = new montajciAdmineIleti();
                    montajciAdmineIleti = item;
                    IletiViews.montajciAdmineIleti.Add(montajciAdmineIleti);
                }
            }
            foreach (var item in db.ureticiAdmineIletis)
            {
                if(item.Id==WebSecurity.CurrentUserId){
                    avizevimde.Areas.Uretici.Models.ureticiAdmineIleti ureticiAdmineIleti = new avizevimde.Areas.Uretici.Models.ureticiAdmineIleti();
                    ureticiAdmineIleti = item;
                    IletiViews.ureticiAdmineIleti.Add(ureticiAdmineIleti);
                }
            }
            foreach (var item in db.tuketiciAdmineIletis){
                if(item.Id==WebSecurity.CurrentUserId){
                    avizevimde.Areas.Tuketici.Models.tuketiciAdmineIleti tuketiciAdmineIleti=new avizevimde.Areas.Tuketici.Models.tuketiciAdmineIleti();
                    tuketiciAdmineIleti=item;
                    IletiViews.tuketiciAdmineIleti.Add(tuketiciAdmineIleti);
                }
            }
            return View(IletiViews);
        } 
        public ActionResult MontajciyaIleti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MontajciyaIleti(adminMontajciyaIleti adminMontajciyaIleti)
        {
            if (ModelState.IsValid)
            {
                adminMontajciyaIleti.adminId = WebSecurity.CurrentUserId;
            }
            return View();
        }
        public ActionResult UreticiyeIleti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UreticiyeIleti(adminUreticiyeIleti adminUreticiyeIleti)
        {
            if (ModelState.IsValid)
            {
                adminUreticiyeIleti.adminId = WebSecurity.CurrentUserId;
            }
            return View();
        }
        public ActionResult TuketiciyeIleti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TuketiciyeIleti(adminTuketiciyeIleti adminTuketiciyeIleti)
        {
            if (ModelState.IsValid)
            {
                adminTuketiciyeIleti.adminId = WebSecurity.CurrentUserId;
            }
            return View();
        }
    }
}
