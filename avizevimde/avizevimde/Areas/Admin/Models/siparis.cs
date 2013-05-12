using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class siparis
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Display(Name = "Tüketici Kodu")]
        [ForeignKey("tuketici")]
        public int TuketiciId { get; set; }

        [Required]
        [Display(Name = "Adı")]
        public string TuketiciAdi { get; set; }

        [Required]
        [Display(Name = "Soyadı")]
        public string TuketiciSoyadi { get; set; }

        [Display(Name = "Adres Kod")]
        public int tuketiciAdresId { get; set; }

        [Required]
        [Display(Name = "Ödeme Türü")]
        public string OdemeTuru { get; set; }

        [Display(Name = "Siparis Listesi Kodu")]
        [ForeignKey("siparisListesi")]
        public int SiparisListesiId { get; set; }

        [Display(Name = "Montaj Kodu")]
        public int MontajEdilecekseId { get; set; }

        [Required]
        [Display(Name = "Teslim Edildi")]
        public int TuketiciTeslimEdildi { get; set; }

        [Required]
        [Display(Name = "Taşımacıya Verdi")]
        public int UreticiTasimaciyaVerdi { get; set; }

        [Display(Name = "Taşıma Şartı Kodu")]
        [ForeignKey("tasimaSarti")]
        public int tasimaSartiId { get; set; }

        [Required]
        [Display(Name = "Tahsil Edildi")]
        public int TuketicidenTahsilEdildi { get; set; }

        [Required]
        [Display(Name = "Ödeme Yapildi/Üretici")]
        public int UreticiyeOdemeYapildi { get; set; }

        [Required]
        [Display(Name = "Ödeme Yapildi/Montajcı")]
        public int MontjaciyaOdemeYapildi { get; set; }

        [Required]
        [Display(Name = "Arama Kodu")]
        public int SiparisTasimaBilgileriAramaId { get; set; }

        [Required]
        [Display(Name = "Admin")]
        public bool AdminOnayVerdi { get; set; }

        [Required]
        [Display(Name = "Toplam")]
        public decimal Total { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        [Display(Name = "Değiştirme Tarihi")]
        public DateTime DegistirmeTarihi { get; set; }

        [Display(Name = "Değiştiren ")]
        public int DegistirenAdmin { get; set; }

        [Required]
        [Display(Name = "Teslim Edildi")]
        public int TeslimEdildi { get; set; }

        [Display(Name = "Üretici")]
        [ForeignKey("uretici")]
        public int UreticiId { get; set; }

        public virtual Areas.Montajci.Models.montajci montajci { get; set; }
        public virtual Areas.Admin.Models.UserProfileAdmin admin { get; set; }
        public virtual avizevimde.Areas.Tuketici.Models.tuketici tuketici { get; set; }
        public virtual Areas.Uretici.Models.uretici uretici { get; set; }
        public virtual avizevimde.Areas.Tuketici.Models.tuketiciAdres tuketiciAdres { get; set; }
        public virtual Areas.Admin.Models.tasimaSarti tasimaSarti { get; set; }
        public virtual siparisListesi siparisListesi { get; set; }
    }
}