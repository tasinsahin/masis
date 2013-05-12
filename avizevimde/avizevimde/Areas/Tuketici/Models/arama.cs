using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class arama
    {
        [Key]
        public int   Id {get;set;}

        [Required]
        [Display(Name="Kelime")]
        public string kelime {get;set;}

        [Required]
        [Display(Name = "Kategori")]
        public int kategoriId {get;set;}

        [Required]
        [Display(Name = "Tüketici")]
        public int tuketiciId{get;set;}

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi {get;set;}

        [ForeignKey("tuketiciId")]
        public virtual Tuketici.Models.tuketici tuketici { get; set; }
        [ForeignKey("kategoriId")]
        public virtual avizevimde.Areas.Admin.Models.kategori kategori { get; set; }
    }
}