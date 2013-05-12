﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Uretici.Models
{
    public class ureticiTuketiciyeIleti
    {
        [Required]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string baslik { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }

        [Required]
        [Display(Name = "Tüketici")]
        public int tuketiciId { get; set; }

        [Required]
        [Display(Name = "Üretici")]
        public int ureticiId { get; set; }

        [Required]
        [Display(Name = "Tarih")]
        public DateTime tarih { get; set; }

        [Required]
        [Display(Name = "Okundu")]
        public bool okundu { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual avizevimde.Areas.Tuketici.Models.tuketici tuketici { get; set; }
        [ForeignKey("ureticiId")]
        public virtual avizevimde.Areas.Uretici.Models.uretici uretici { get; set; }
    }
}