using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class marka
    {
        [Key]
        [Display(Name = "Kodu")]
        public int  Id { get; set; }

        [Required]
        [Display(Name = "Tanım")]
        public string  tanim { get; set; } 

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int? degistirenId { get; set; }
        
        [Required]
        [Display(Name = "Değiştirilen")]
        public int degistirilenId { get; set; }

        [Required]
        [Display(Name = "En Yeni")]
        public bool enYeni { get; set; }

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