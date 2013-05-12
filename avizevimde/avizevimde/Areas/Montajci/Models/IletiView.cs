using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Montajci.Models
{
    public class IletiView
    {
        public List<avizevimde.Areas.Tuketici.Models.tuketiciMontajciyaIleti> tuketiciMontajciyaIleti { get; set; }
        public List<avizevimde.Areas.Admin.Models.adminMontajciyaIleti> adminMontajciyaIleti { get; set; }
    }
}