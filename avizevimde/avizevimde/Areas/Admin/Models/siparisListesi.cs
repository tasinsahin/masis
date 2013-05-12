using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class siparisListesi
    {
        [Key]
        public int siparisUrunListesiId { get; set; }

        [Display(Name = "Kodu")]
        public int urunId { get; set; }

        [Required]
        [Display(Name = "Adet")]
        public int urunAdedi { get; set; }

        [Required]
        [Display(Name = "Fiyat")]
        public int urunFiyati { get; set; }

        [Required]
        [Display(Name = "Toplam")]
        public decimal total { get; set; }

        [ForeignKey("urunId")]
        public virtual Areas.Admin.Models.urun urun { get; set; }
    }
}