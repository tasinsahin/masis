using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace avizevimde.Models
{
    public class oneri
    {
        [Key]
        [Display(Name="Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name="Adınız")]
        public string adi { get; set; }

        [Required]
        [Display(Name = "Soyadınız")]
        public string soyAdi { get; set; }

        [Required]
        [Display(Name = "E-Posta")]
        public string Eposta { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string baslik { get; set; }
             
        [Required]
        [Display(Name="İçerik")]
        public string icerik { get; set; }
          
        [Required]
        [Display(Name="Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }
    }
}