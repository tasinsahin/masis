using avizevimde.avizeevimdeDB__avizevimde.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace avizevimde.Areas.Uretici.Controllers
{
    public class IletiController : Controller
    {
        //
        // GET: /Uretici/UreticiIleti/
        private Models_ db = new Models_();
        public avizevimde.Areas.Uretici.Models.IletiView iletiView = new avizevimde.Areas.Uretici.Models.IletiView();
        public ActionResult Index()
        {
            foreach (var item in db.adminUreticiyeIletis)
            {
                avizevimde.Areas.Admin.Models.adminUreticiyeIleti adminUreticiyeIleti=new avizevimde.Areas.Admin.Models.adminUreticiyeIleti();
                if(item.Id==WebSecurity.CurrentUserId){
                    adminUreticiyeIleti=item;
                    iletiView.adminUreticiyeIleti.Add(adminUreticiyeIleti);
                }
            }
            foreach (var item in db.tuketiciUreticiyeIletis)
            {
                avizevimde.Areas.Tuketici.Models.tuketiciUreticiyeIleti tuketiciUreticiyeIleti = new avizevimde.Areas.Tuketici.Models.tuketiciUreticiyeIleti();
                if(item.Id==WebSecurity.CurrentUserId){
                    tuketiciUreticiyeIleti = item;
                    iletiView.tuketiciUreticiyeIleti.Add(tuketiciUreticiyeIleti);
                }
            }
            return View();
        }
        public ActionResult AdmineIleti()
        {
            return View();
        }
        public ActionResult TuketiciyeIleti()
        {
            return View();
        }

    }
}
