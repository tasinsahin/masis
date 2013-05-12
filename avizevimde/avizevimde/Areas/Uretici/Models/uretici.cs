using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Uretici.Models
{
    public class uretici
    {
        [Key]
        [Display(Name="Kodu")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Adı")]
        public int adi { get; set; }

        [Required(ErrorMessage = "Lütfen  Adınızı Giriniz")]
        [Display(Name = "Üretici")]
        public string ureticiAdi { get; set; }

        [Required(ErrorMessage = "Lütfen İcerik Giriniz")]
        [Display(Name = "Tanım")]
        public string ureticiTanim { get; set; }

        [Required(ErrorMessage = "Lütfen Telefonunuzu Giriniz")]
        [Display(Name = "Telefon")]
        public string ureticiTelefon1 { get; set; }

        [Required(ErrorMessage = "Lütfen Telefonunuzu Giriniz")]
        [Display(Name = "Telefon")]
        public string ureticiTelefon2 { get; set; }

        [Required(ErrorMessage = "Lütfen Cep Telefonunuzu Giriniz")]
        [Display(Name = "Cep Telefonu")]
        public string ureticiCepTelefonu { get; set; }

        [Required(ErrorMessage = "Lütfen  Eposta Adresinizi Giriniz")]
        [Display(Name = "E-Posta")]
        public string ureticiEpostaAdresi { get; set; }

        [Required]
        [Display(Name = "Ozel Tasarım")]
        public bool ozelTasarimYapiyor { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Display(Name = "Değiştirme Tarihi")]
        public DateTime degistirmeTarihi { get; set; }

    }
}