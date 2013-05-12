using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class smsTuketici
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public int baslik { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public int icerik { get; set; }

        [Display(Name = "Tüketici")]
        public int tuketiciId { get; set; }

        [Required]
        [Display(Name = "Tarih")]
        public DateTime smsTarihi { get; set; }

        [Required]
        [Display(Name = "Numara")]
        public int smsNumara { get; set; }
         

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
        [ForeignKey("tuketiciId")]
        public virtual avizevimde.Areas.Tuketici.Models.tuketici tuketici { get; set; }
    }
         
}