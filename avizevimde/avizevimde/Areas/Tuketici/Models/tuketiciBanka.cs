using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class tuketiciBanka
    {
        [Key]
        [Display(Name = "Kodu")]
        public int  Id { get; set; }

        [Display(Name = "Tüketici")]
        public int tuketiciId { get; set; }

        [Display(Name = "Banka")]
        public int bankaId { get; set; }

        [Display(Name = "Banka Şube")]
        public int bankaSubeId { get; set; }

        [Required]
        [Display(Name = "Hesap Numarası")]
        public int hesapNumarasi { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Display(Name = "Değiştirilen")]
        public int degistirilenId { get; set; }

        [Display(Name = "En Yeni")]
        public bool enYeni { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual tuketici tuketici { get; set; }
        [ForeignKey("bankaId")]
        public virtual avizevimde.Areas.Admin.Models.banka banka { get; set; }
        [ForeignKey("bankaSubeId")]
        public virtual avizevimde.Areas.Admin.Models.bankaSube bankaSube { get; set; }
    }
}