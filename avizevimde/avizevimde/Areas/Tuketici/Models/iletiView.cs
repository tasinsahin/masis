using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class iletiView
    {
        public List<avizevimde.Areas.Admin.Models.adminTuketiciyeIleti> adminTuketiyeIleti { get; set; }
        public List<avizevimde.Areas.Montajci.Models.montajciTuketiciyeIleti> montajciTuketiciyeIleti { get; set; }
        public List<avizevimde.Areas.Uretici.Models.ureticiTuketiciyeIleti> ureticiTuketiciyeIleti { get; set; }
    }
}