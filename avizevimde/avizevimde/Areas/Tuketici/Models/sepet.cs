using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class sepet
    {
        [Required]
        [Display(Name="Kodu")]
        public int  Id { get; set; }

        [ForeignKey("tuketici")]
        public int tuketiciId { get; set; }


        [Required]
        [Display(Name = "Adet")]
        public int urunAdedi { get; set; }

        [Display(Name = "Oda")]
        public int  odaId { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }


        [Display(Name = "Değiştirme Tarihi")]
        public DateTime degistirmeTarihi { get; set; }


        [Display(Name = "tuketiciId")]
        public virtual tuketici tuketici { get; set; }
        [ForeignKey("odaId")]
        public virtual oda oda { get; set; }
     }
}