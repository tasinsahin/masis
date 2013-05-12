using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Uretici.Models
{
    public class ureticiLog
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kaynak")]
        public string kaynak { get; set; }

        [Required]
        [Display(Name = "Olay")]
        public string olay { get; set; }

        [Display(Name = "Üretici")]
        public int ureticiId { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [ForeignKey("ureticiId")]
        public virtual uretici uretici { get; set; }
    }
}