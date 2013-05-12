using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class logo
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen  Açıklama Giriniz")]
        [Display(Name = "Açıklaması")]
        public string aciklamasi { get; set; }

        [Required]
        [Display(Name = "URL")]
        public string url { get; set; }

        [Required(ErrorMessage = "Lütfen  Varsayılan Giriniz")]
        [Display(Name = "Varsayılan")]
        public bool varsayilan { get; set; }

        [Required(ErrorMessage = "Lütfen  Alt Giriniz")]
        [Display(Name = "Alt")]
        public string alt { get; set; }

        [Required(ErrorMessage = "Lütfen  Tanım Giriniz")]
        [Display(Name = "Tanım")]
        public string tanim { get; set; }

        [Required(ErrorMessage = "Lütfen Anahtar Kelime Giriniz")]
        [Display(Name = "Anahtar Kelime")]
        public string anahtarKelime { get; set; }
         

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime? eklenmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [Display(Name = "Değiştiren")]
        public int? degistirenId { get; set; }

        [ForeignKey("ekleyenId")]
        public virtual UserProfileAdmin ekleyen { get; set; }         
        [ForeignKey("degistirenId")]
        public virtual UserProfileAdmin degistiren { get; set; }


    }
}