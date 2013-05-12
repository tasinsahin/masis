using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class IletiView
    {
        public List<avizevimde.Areas.Montajci.Models.montajciAdmineIleti> montajciAdmineIleti { get; set; }
        public List<avizevimde.Areas.Uretici.Models.ureticiAdmineIleti> ureticiAdmineIleti { get; set; }
        public List<avizevimde.Areas.Tuketici.Models.tuketiciAdmineIleti> tuketiciAdmineIleti { get; set; }
    }
}