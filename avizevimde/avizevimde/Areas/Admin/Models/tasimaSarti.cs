using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class tasimaSarti
    {
        [Key]
        [Display(Name = "Kodu")]
        public int  Id { get; set; }

        [Required]
        [Display(Name = "Mesafe")]
        public int mesafe { get; set; }

        [Required]
        [Display(Name = "Ağırlık")]
        public int agirlik { get; set; }

        [Required]
        [Display(Name = "Hacim")]
        public int hacim { get; set; }

        [Required]
        [Display(Name = "Fiyatı")]
        public int fiyati { get; set; }
         

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Değiştiren")]
        public int degistirenId { get; set; }

        [Display(Name = "Değiştirilen")]
        public int degistirilenId { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime? eklenmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [Required]
        [Display(Name = "En Yeni")]
        public bool enYeni { get; set; }

        [ForeignKey("ekleyenId")]
        public virtual UserProfileAdmin ekleyen { get; set; }
        [ForeignKey("degistirenId")]
        public virtual UserProfileAdmin degistiren { get; set; } 
    }
}