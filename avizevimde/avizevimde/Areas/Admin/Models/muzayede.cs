using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class muzayede
    {
        [Key]
        [Display(Name="Kodu")]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Sipariş Kodu")]
        public int siparisId { get; set; }

        [Required]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime baslangic { get; set; }

        [Required]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime bitis { get; set; } 

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Değiştiren")]
        public DateTime? degistirenId { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime? eklenmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [ForeignKey("ekleyenId")]
        public virtual UserProfileAdmin ekleyen { get; set; }
        [ForeignKey("siparisId")]
        public virtual avizevimde.Areas.Admin.Models.siparis siparis { get; set; } 
        [ForeignKey("degistirenId")]
        public virtual UserProfileAdmin degistiren { get; set; }
    }
}
