using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class montajSorun
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sipariş Kodu")]
        public int siparisId { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }

        [Required]
        [Display(Name = "Montajcı")]
        public int montajciId { get; set; }

        [Required]
        [Display(Name = "Montaj Yapıldı")]
        public bool montajYapildi { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime degistirmeTarihi { get; set; }

        [Required]
        [Display(Name = "Tüketici")]
        public int tuketiciId { get; set; }

        [Required]
        [Display(Name="Sorun Bildiren")]
        public bool sorunBildirenMT { get; set; }

        [ForeignKey("tuketiciId")]
        public virtual tuketici tuketici { get; set; }
        [ForeignKey("siparisId")]
        public virtual avizevimde.Areas.Admin.Models.siparis siparis { get; set; }
    }
}