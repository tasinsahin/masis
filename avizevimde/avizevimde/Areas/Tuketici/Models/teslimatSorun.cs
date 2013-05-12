using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class teslimatSorun
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Display(Name = "Sipariş Kodu")]
        public int siparisId { get; set; }

        [Display(Name = "İçerik")]
        public string icerik { get; set; }
        
        [Display(Name = "Sipariş Teslim Alındı")]
        public bool siparisTeslimAlindi { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime degistirmeTarihi { get; set; }

        [Display(Name = "Tüketici")]
        public int tuketiciId { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual tuketici tuketici { get; set; }
        [ForeignKey("siparisId")]
        public virtual avizevimde.Areas.Admin.Models.siparis siparis { get; set; }

    }
}