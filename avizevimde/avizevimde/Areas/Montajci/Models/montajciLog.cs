using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Montajci.Models
{
    public class montajciLog
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kaynak")]
        public int kaynak { get; set; }

        [Required]
        [Display(Name = "Zaman")]
        public int zaman { get; set; }

        [Required]
        [Display(Name = "Olay")]
        public int olay { get; set; }

        [Display(Name = "Montajcı")]
        public int MontajciId { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [ForeignKey("MontajciId")]
        public virtual avizevimde.Areas.Montajci.Models.montajci montajci { get; set; }
         
    }
}