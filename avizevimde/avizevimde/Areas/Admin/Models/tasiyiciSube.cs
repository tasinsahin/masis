using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class tasiyiciSube
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Adı")]
        public int subeAdi { get; set; }

        [Required]
        [Display(Name = "Şehir")]
        public int sehirId { get; set; }

        [Required]
        [Display(Name = "İlçe")]
        public int ilceId { get; set; }

        [Required]
        [Display(Name = "Semt")]
        public int semtId { get; set; }

        [Required]
        [Display(Name = "Mahalle")]
        public int mahalleId { get; set; }

        [Required]
        [Display(Name = "Cadde")]
        public string cadde { get; set; }

        [Required]
        [Display(Name = "Sokak")]
        public string sokak { get; set; }

        [Required]
        [Display(Name = "Numara")]
        public string numara { get; set; }

        [Required]
        [Display(Name = "Fatura Adresi")]
        public bool faturaAdresi { get; set; }

        [Required]
        [Display(Name = "Enlem")]
        public string enlem { get; set; }

        [Required]
        [Display(Name = "Boylam")]
        public string boylam { get; set; }
         
        [Display(Name = "Değiştirme Tarihi")]
        public DateTime? degistirmeTarihi { get; set; }

        [Display(Name = "Değiştiren")]
        public int degistirenId { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime? eklenmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [ForeignKey("ekleyenId")]
        public virtual UserProfileAdmin ekleyen { get; set; }         
        [ForeignKey("degistirenId")]
        public virtual UserProfileAdmin degistiren { get; set; }
        [ForeignKey("sehirId")]
        public virtual sehir sehir { get; set; }
        [ForeignKey("ilceId")]
        public virtual ilce ilce { get; set; }
        [ForeignKey("mahalleId")]
        public virtual mahalle mahalle { get; set; }
        [ForeignKey("semtId")]
        public virtual semt semt { get; set; }
    }
}