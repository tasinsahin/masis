using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class urun
    {
        [Key]
        [Required]
        [Display(Name="Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Renk")]
        public int renkId { get; set; }

        [Required]
        [Display(Name = "Marka")]
        public int markaId { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int kategoriId { get; set; }

        [Required]
        [Display(Name = "Alt")]
        public string alt { get; set; }

        [Required]
        [Display(Name = "Aranma")]
        public string aramaBilgileri { get; set; }

        [Required]
        [Display(Name = "Ağırlık")]
        public string agirlik { get; set; }

        [Required]
        [Display(Name = "Tanıtım")]
        public string tanitim { get; set; }

        [Required]
        [Display(Name = "Resim1")]
        public string resim1 { get; set; }

        [Required]
        [Display(Name = "Resim2")]
        public string resim2 { get; set; }

        [Required]
        [Display(Name = "Resim3")]
        public string resim3 { get; set; }

        [Required]
        [Display(Name = "Yayınlansın")]
        public int yayinlansin { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Required]
        [Display(Name = "Üretici")]
        public int ureticiId { get; set; }

        [Required]
        [Display(Name = "Fiyat")]
        public decimal fiyat { get; set; }

        [Required]
        [Display(Name = "Taksit")]
        public int taksitId { get; set; }

        [Required]
        [Display(Name = "Vergi")]
        public int vergiId { get; set; }

        [Required]
        [Display(Name = "Admin Onay")]
        public bool adminOnayVerdi { get; set; }

        [Required]
        [Display(Name = "Kargo Dahil")]
        public bool kargoDahil { get; set; }

        [Required]
        [Display(Name = "Montaj Dahil")]
        public bool montajDahil { get; set; }

        [ForeignKey("renkId")]
        public virtual avizevimde.Areas.Admin.Models.renk renk { get; set; }
        [ForeignKey("kategoriId")]
        public virtual avizevimde.Areas.Admin.Models.kategori kategori { get; set; }
        [ForeignKey("vergiId")]
        public virtual avizevimde.Areas.Admin.Models.vergi vergi { get; set; }
        [ForeignKey("markaId")]
        public virtual avizevimde.Areas.Admin.Models.marka marka { get; set; }
        [ForeignKey("taksitId")]
        public virtual avizevimde.Areas.Admin.Models.taksit taksit { get; set; }
        [ForeignKey("ureticiId")]
        public virtual avizevimde.Areas.Uretici.Models.uretici uretici { get; set; }
    }
}     