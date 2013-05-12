using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class tuketiciFatura
    {
        [Key]
        [Display(Name = "Kodu")]
        public int  Id { get; set; }

        [Display(Name = "Tüketici")]
        public int tuketiciId { get; set; }

        [Display(Name = "Adres Kodu")]
        public int adresId { get; set; }

        [Display(Name = "Vergi Dairesi")]
        public int vergiDairesiId { get; set; }

        [Required]
        [Display(Name = "Vergi Numarası")]
        public int vergiNumarasi { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Display(Name = "Değiştirilen")]
        public int degistirilenId { get; set; }

        [Required]
        [Display(Name = "En Yeni")]
        public bool enYeni { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual tuketici tuketici { get; set; }
        [ForeignKey("adresId")]
        public virtual tuketiciAdres tuketiciAdres { get; set; }
        [ForeignKey("vergiDairesiId")]
        public virtual Areas.Admin.Models.vergiDairesi vergiDairesi { get; set; }
    }
}