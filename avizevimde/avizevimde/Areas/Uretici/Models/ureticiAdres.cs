﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Uretici.Models
{
    public class ureticiAdres
    {
        [Key]
        [Required]
        [Display(Name="Kodu")]
        public int Id { get; set; }
        
        [Required]
        [Display(Name="Üretici")]
        public int ureticiId { get; set; }
        
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
        [Display(Name="Cadde")]
        public string cadde { get; set; }

        [Required]
        [Display(Name="Sokak")]
        public string sokak { get; set; }

        [Required]
        [Display(Name="Numara")]
        public string numara { get; set; }

        [Required]
        [Display(Name="Enlem")]
        public int enlem { get; set; }

        [Required]
        [Display(Name="Boylam")]
        public int boylam { get; set; }

        [Required]
        [Display(Name="Adres Adı")]
        public int adresAdi { get; set; }

        [Required]
        [Display(Name="Fatura")]
        public bool adresFatura { get; set; }

        [Required]
        [Display(Name="Teslimat")]
        public bool adresTeslimat { get; set; }

        [Required]
        [Display(Name="Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        [Display(Name="Değiştirilen")]
        public int degistirilenId { get; set; }
        
        [Display(Name="En Yeni")]
        public bool enYeni { get; set; }

        [ForeignKey("ureticiId")]
        public virtual uretici uretici { get; set; }
        [ForeignKey("sehirId")]
        public virtual avizevimde.Areas.Admin.Models.sehir sehir { get; set; }
        [ForeignKey("ilceId")]
        public virtual avizevimde.Areas.Admin.Models.ilce ilce { get; set; }
        [ForeignKey("mahalleId")]
        public virtual avizevimde.Areas.Admin.Models.mahalle mahalle { get; set; }
        [ForeignKey("semtId")]
        public virtual avizevimde.Areas.Admin.Models.semt semt { get; set; }
    }
}