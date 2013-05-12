using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class soru
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name="Tüketici")]
        public int tuketiciId { get; set; }

        [Required]
        [Display(Name = "Adı")]
        public string adi { get; set; }

        [Required]
        [Display(Name = "Soyadı")]
        public string soyadi { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string baslik { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual tuketici tuketici { get; set; }
    }
}