using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class smsMontajci
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

        [Required]
        [Display(Name = "Montajcı")]
        public int montajciId { get; set; }

        [Required]
        [Display(Name = "Tarih")]
        public DateTime? smsTarihi { get; set; }

        [Required]
        [Display(Name = "Numara")]
        public int smsNumara { get; set; } 

        [Display(Name = "Eklenme Tarihi")]
        public DateTime? eklenmeTarihi { get; set; }

        [Display(Name = "Ekleyen")]
        public int ekleyenId { get; set; }

        [ForeignKey("ekleyenId")]
        public virtual UserProfileAdmin ekleyen { get; set; } 
        [ForeignKey("montajciId")]
        public virtual avizevimde.Areas.Montajci.Models.montajci montajci { get; set; }
    }
}