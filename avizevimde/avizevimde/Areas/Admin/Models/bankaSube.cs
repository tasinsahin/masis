using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class bankaSube
    {
        [Key]
        [Display(Name = "Kodu")]
        public int  Id { get; set; }

        [Display(Name="Banka")]
        public int bankaId { get; set; }

        [Required(ErrorMessage = "Lütfen Şube Adı Giriniz")]
        [Display(Name = "Şube Adı")]
        public string bankaSubeAdi { get; set; }

        [Required(ErrorMessage = "Lütfen Şube Telefon Giriniz")]
        [Display(Name = "Telefon")]
        public string bankaSubeCagriMerkeziTelefon { get; set; }

        [Display(Name = "Telefon")]
        public string bankaSubeOzelTelefon { get; set; }
        
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
        [ForeignKey("bankaId")]
        public virtual banka banka { get; set; }
    }
}