using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace avizevimde.Areas.Tuketici.Controllers
{
    public class IletiController : avizevimde.Areas.Tuketici.Controllers.AccountController
    {
        //
        // GET: /Tuketici/TuketiciIleti/
        private Models_ db = new Models_();
        public ActionResult Index( )
        {
            avizevimde.Areas.Tuketici.Models.iletiView iletiView = new avizevimde.Areas.Tuketici.Models.iletiView();
            foreach (var item in db.adminTuketiciyeIletis)
            {
                avizevimde.Areas.Admin.Models.adminTuketiciyeIleti adminTuketiciyeIleti = new avizevimde.Areas.Admin.Models.adminTuketiciyeIleti();
                if (item.Id == WebSecurity.CurrentUserId)
                {
                    adminTuketiciyeIleti = item;
                    iletiView.adminTuketiyeIleti.Add(adminTuketiciyeIleti);
                }
            }
            foreach (var item in db.montajciTuketiciyeIletis)
            {
                avizevimde.Areas.Montajci.Models.montajciTuketiciyeIleti montajciTuketiciyeIleti = new Montajci.Models.montajciTuketiciyeIleti();
                if (item.Id == WebSecurity.CurrentUserId)
                {
                    montajciTuketiciyeIleti = item;
                    iletiView.montajciTuketiciyeIleti.Add(montajciTuketiciyeIleti);
                }                
            }
            foreach (var item in db.ureticiTuketiciyeIleti)
            {
                avizevimde.Areas.Uretici.Models.ureticiTuketiciyeIleti ureticiTuketiciyeIleti = new avizevimde.Areas.Uretici.Models.ureticiTuketiciyeIleti();
                if (item.Id == WebSecurity.CurrentUserId)
                {
                    ureticiTuketiciyeIleti = item;
                    iletiView.ureticiTuketiciyeIleti.Add(ureticiTuketiciyeIleti);
                }                
            }
            return View(iletiView);
        }
        public ActionResult MontajciyaIleti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MontajciyaIleti(avizevimde.Areas.Tuketici.Models.tuketiciMontajciyaIleti tuketiciMontajciyaIleti)
        {
            if (ModelState.IsValid)
            {
                tuketiciMontajciyaIleti.tuketiciId = WebSecurity.CurrentUserId;
            }
            return View();
        } 
        public ActionResult UreticiyeIleti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UreticiyeIleti(avizevimde.Areas.Tuketici.Models.tuketiciUreticiyeIleti tuketiciUreticiyeIleti)
        {
            if (ModelState.IsValid)
            {
                tuketiciUreticiyeIleti.tuketiciId = WebSecurity.CurrentUserId;
            }
            return View();
        }
        public ActionResult AdmineIleti(avizevimde.Areas.Tuketici.Models.tuketiciAdmineIleti tuketiciAdmineIleti)
        {
            if (ModelState.IsValid)
            {
                tuketiciAdmineIleti.tuketiciId = WebSecurity.CurrentUserId;
            }
            return View();
        } 
    }
}
