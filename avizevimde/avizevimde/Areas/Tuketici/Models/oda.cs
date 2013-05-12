using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class oda
    {
        [Key]
        [Display(Name="Kodu")]
        public int Id { get; set; }


        [Display(Name="Tüketici")]
        public int tuketiciId { get; set; }

        [Required]
        [Display(Name = "resim")]
        public string resim { get; set; }

        [Required]
        [Display(Name = "Resim Adı")]
        public string resimAdi { get; set; }


        [Required]
        [Display(Name = "Oda Alanı")]
        public int odaAlani { get; set; }

        [Required]
        [Display(Name = "Oda Yükseklik")]
        public int odaYukseklik { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime degistirmeTarihi { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual tuketici tuketici { get; set; }
         
    }
}