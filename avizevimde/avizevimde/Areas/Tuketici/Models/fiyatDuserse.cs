using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class fiyatDuserse
    {
        [Key]
        [Display(Name="Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ürün")]
        public int urunId { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Required]
        [Display(Name = "Tüketici")]
        public int tuketiciId { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual tuketici tuketici { get; set; }
        [ForeignKey("urunId")]
        public virtual avizevimde.Areas.Admin.Models.urun urun { get; set; }
    }
}