using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class urun2
    {
        [Required]
        [Display(Name="Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Adı")]
        public int adi { get; set; }

        [Required]
        [Display(Name = "Açıklaması")]
        public string aciklamasi { get; set; }

        [Required]
        [Display(Name = "URL")]
        public string url { get; set; }

        [Required]
        [Display(Name = "Stok")]
        public int stokAdedi { get; set; }

        [Required]
        [Display(Name = "İzlenme Sayısı")]
        public int izlenmeSayisi { get; set; }

        [Required]
        [Display(Name = "Alt")]
        public string alt { get; set; }

        [Required]
        [Display(Name = "SEO")]
        public string seo { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Required]
        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [Required]
        [Display(Name = "Değiştirme Tarihi")]
        public DateTime degistirmeTarihi { get; set; }

        [Required]
        [Display(Name = "Değiştiren")]
        public int degistirenId { get; set; }

        [Required]
        [Display(Name = "Fiyat")]
        public decimal fiyat { get; set; }

        [Display(Name = "Değiştirilen")]
        public int urunBilgileriDegistirilenId { get; set; }

        [Required]
        [Display(Name = "En Yeni")]
        public bool urunBilgileriDegistirlenEnYeni { get; set; }
    }
}