using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class banner
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Açıklama")]
        public string aciklama { get; set; }

        [Required]
        [Display(Name = "URL")]
        public string url { get; set; }

        [Required]
        [Display(Name = "Varsayılan")]
        public string varsayilan { get; set; }

        [Required]
        [Display(Name = "Alt")]
        public string alt { get; set; }

        [Required]
        [Display(Name = "Tanım")]
        public int tanim { get; set; }

        [Required]
        [Display(Name = "Anahtar Kelime")]
        public int anahtarKelime { get; set; }
                
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