using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class montaj
    {
        public int siparisId { get; set; }
        public int montajciId { get; set; }
        public DateTime montajTarihi { get; set; }
        public decimal tutar { get; set; }
        public bool odemeYapildi { get; set; }
        public bool montajYapildiMontajci { get; set; }
        public bool montajYapildiTuketici { get; set; }
        public DateTime eklenmeTarihi { get; set; }
        public DateTime degistirmeTarihi { get; set; }

        [ForeignKey("montajciId")]
        public virtual Montajci.Models.montajci montajci { get; set; }
        [ForeignKey("siparisId")]
        public virtual Admin.Models.siparis siparis { get; set; }
    }
}
