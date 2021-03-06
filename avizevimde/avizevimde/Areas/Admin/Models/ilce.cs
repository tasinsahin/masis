﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{

    public class ilce
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Display(Name = "Şehir")]
        public int sehirId { get; set; }

        [Required]
        [Display(Name = "Adı")]
        public string ilceAdi { get; set; }
        
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
        [ForeignKey("sehirId")]
        public virtual sehir sehir { get; set; }
        [ForeignKey("degistirenId")]
        public virtual UserProfileAdmin degistiren { get; set; }
        public virtual ICollection<semt> semtler { get; set; }

    }
 
}