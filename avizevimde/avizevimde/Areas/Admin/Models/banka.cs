using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class banka
    {
        [Key]
        [Display(Name = "Kodu")]
        public int bankaId { get; set; }

        [Required(ErrorMessage = "Lütfen Banka Adı Giriniz")]
        [Display(Name = "Adı")]
        public string bankaAdi { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Giriniz")]
        [Display(Name = "Telefon")]
        public string bankaCagriAdresiTelefon { get; set; }

        [Required(ErrorMessage = "Lütfen  Telefon Giriniz")]
        [Display(Name = "Telefon")]
        public string bankaOzelTelefon { get; set; }
                
        
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