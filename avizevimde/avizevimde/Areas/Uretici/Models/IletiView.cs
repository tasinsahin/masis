using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Uretici.Models
{
    public class IletiView
    {
        public List<avizevimde.Areas.Admin.Models.adminUreticiyeIleti> adminUreticiyeIleti { get; set; }
        public List<avizevimde.Areas.Tuketici.Models.tuketiciUreticiyeIleti> tuketiciUreticiyeIleti { get; set; }
    }
}