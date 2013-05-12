using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace avizevimde.Areas.Montajci.Controllers
{
    public class IletiController : avizevimde.Areas.Montajci.Controllers.AccountController
    {
        //
        // GET: /Montajci/MontajciIleti/

        private avizevimde.avizeevimdeDB__avizevimde.Areas.Admin.Models_ db = new avizevimde.avizeevimdeDB__avizevimde.Areas.Admin.Models_();
        public ActionResult Index()
        {
            avizevimde.Areas.Montajci.Models.IletiView iletiView = new avizevimde.Areas.Montajci.Models.IletiView();
 
            avizevimde.Areas.Admin.Models.adminMontajciyaIleti adminMontajciyaIleti = new Admin.Models.adminMontajciyaIleti();
            foreach (var item in db.adminMontajciyaIletis)
            {
                if(item.Id==WebMatrix.WebData.WebSecurity.CurrentUserId){
                    adminMontajciyaIleti = item;
                    iletiView.adminMontajciyaIleti.Add(adminMontajciyaIleti);
                }
            }
            avizevimde.Areas.Tuketici.Models.tuketiciMontajciyaIleti tuketiciMontajciyaIleti = new Tuketici.Models.tuketiciMontajciyaIleti();
            foreach (var item in db.tuketiciMontajciyaIletis)
            {
                if (item.Id == WebMatrix.WebData.WebSecurity.CurrentUserId)
                {
                    tuketiciMontajciyaIleti = item;
                    iletiView.tuketiciMontajciyaIleti.Add(tuketiciMontajciyaIleti);
                }                
            }
            return View();
        }

        public ActionResult AdmineIleti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdmineIleti(avizevimde.Areas.Montajci.Models.montajciAdmineIleti montajciAdmineIleti) 
        {
            if (ModelState.IsValid)
            {
                montajciAdmineIleti.montajciId = WebSecurity.CurrentUserId;
            }
            return View();
        }
        public ActionResult TuketiciyeIleti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TuketiciyeIleti(avizevimde.Areas.Montajci.Models.montajciTuketiciyeIleti montajciTuketiciyeIleti)
        {
            if (ModelState.IsValid)
            {
                montajciTuketiciyeIleti.montajciId = WebSecurity.CurrentUserId;
            }
            return View();
        }


    }
}
