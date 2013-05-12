using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Montajci.Models
{
    public class MontajciFatura
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Display(Name = "Montajcı")]
        public int montajciId { get; set; }

        [Display(Name = "Adres")]
        public int adresId { get; set; }

        [Display(Name = "Vergi Dairesi")]
        public int vergiDairesiId { get; set; }

        [Required]
        [Display(Name = "Vergi Numarası")]
        public int vergiNumarasi { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }
        
        [Display(Name = "Değiştirilen")]
        public int degistirilenId { get; set; }

        [Required]
        [Display(Name = "En Yeni")]
        public bool enYeni { get; set; }

        [ForeignKey("montajciId")]
        public virtual montajci montajci { get; set; }
        [ForeignKey("adresId")]
        public virtual MontajciAdres adres { get; set; }
        [ForeignKey("vergiDairesiId")]
        public virtual avizevimde.Areas.Admin.Models.vergiDairesi vergiDairesi { get; set; }
    }
}