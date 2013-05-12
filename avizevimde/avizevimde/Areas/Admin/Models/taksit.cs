using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class taksit
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Taksit Sayısı")]
        public int taksitSayisi { get; set; }

        [Required]
        [Display(Name = "Kart Adı")]
        public string kartAdi { get; set; }
                 
        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int? degistirenId { get; set; }

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