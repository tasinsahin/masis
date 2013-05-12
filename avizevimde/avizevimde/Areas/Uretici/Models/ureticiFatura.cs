using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Uretici.Models
{
    public class ureticiFatura
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Display(Name = "Üretici")]
        public int ureticiId { get; set; }

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

        [ForeignKey("ureticiId")]
        public virtual uretici uretici { get; set; }
        [ForeignKey("vergiDairesiId")]
        public virtual avizevimde.Areas.Admin.Models.vergiDairesi vergiDairesi { get; set; }
        [ForeignKey("adresId")]
        public virtual ureticiAdres adres { get; set; }

    }
}