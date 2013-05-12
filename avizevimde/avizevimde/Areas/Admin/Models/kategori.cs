using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class kategori
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Açıklama")]
        public string aciklama { get; set; }

        [Required]
        [Display(Name = "Anahtar Kelime")]
        public string anahtarKelime { get; set; }

        [Required]
        [Display(Name = "Alt Tanım")]
        public string altTanim { get; set; }

        [Required]
        [Display(Name = "Adı")]
        public string adi { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string baslik { get; set; } 
        
        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime? eklenmeTarihi { get; set; }

        [Display(Name = "Değiştiren")]
        public int? degistirenId { get; set; } 

        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [ForeignKey("ekleyenId")]
        public virtual UserProfileAdmin ekleyen { get; set; }
        [ForeignKey("degistirenId")]
        public virtual UserProfileAdmin degistiren { get; set; }
    }
}