using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Tuketici.Models
{
    public class tuketici
    {
        [Key]
        [Display(Name = "Kodu")]
        public int tuketiciId { get; set; }

        [Required(ErrorMessage = "Lütfen  Adınızı Giriniz")]
        [Display(Name = "Adı")]
        public string tuketiciAdi { get; set; }

        [Required(ErrorMessage = "Lütfen  Soyadınızı Giriniz")]
        [Display(Name = "Soyadı")]
        public string tuketiciSoyadi { get; set; }

        [Required]
        [Display(Name = "Cinsiyet")]
        public string tuketiciCinsiyet { get; set; }

        [Required]
        [Display(Name = "Cep Telefonu")]
        public string tuketiciCepTelefonu { get; set; }

        [Required(ErrorMessage = "Lütfen  Eposta Adresinizi Giriniz")]
        [Display(Name = "E-Posta")]
        public string tuketiciEpostaAdresi { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime tuketiciDogumTarihi { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime DegistirmeTarihi { get; set; }

    }
}