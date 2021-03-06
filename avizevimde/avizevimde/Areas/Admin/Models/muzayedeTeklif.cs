﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class muzayedeTeklif
    {
        [Key]
        [Display(Name="Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sipariş Kodu")]
        public int siparisId { get; set; }

        [Required]
        [Display(Name = "Montajcı")]
        public int montajciId { get; set; }

        [Required]
        [Display(Name = "Montaj Tarihi")]
        public DateTime montajTarihi { get; set; }

        [Required]
        [Display(Name = "Montaj Saati")]
        public DateTime montajSaati { get; set; }

        [Required]
        [Display(Name = "Tutar")]
        public decimal tutar { get; set; }
         
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
        [ForeignKey("siparisId")]
        public virtual avizevimde.Areas.Admin.Models.siparis siparis { get; set; }
        [ForeignKey("montajciId")]
        public virtual avizevimde.Areas.Montajci.Models.montajci montajci { get; set; }
    }
}