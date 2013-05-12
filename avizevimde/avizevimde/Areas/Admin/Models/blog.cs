using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class blog
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string baslik { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }

        [Required]
        [Display(Name = "Anahtar Kelime")]
        public string anahtarKelime { get; set; }

        [Required]
        [Display(Name = "Alt")]
        public string alt { get; set; }

        public string resim1 { get; set; }
        public string resim2 { get; set; }
        public string resim3 { get; set; }
        public string resim4 { get; set; }

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Değiştiren")]
        public int? degistirenId { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime? eklenmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [ForeignKey("ekleyenId")]
        public virtual UserProfileAdmin ekleyen { get; set; }
        [ForeignKey("degistirenId")]
        public virtual UserProfileAdmin degistiren { get; set; }
    }
}