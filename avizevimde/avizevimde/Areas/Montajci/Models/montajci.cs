using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Montajci.Models
{
    public class montajci
    {
        [Key]
        [Display(Name="Kodu")]
        public int id { get; set; }

        [Display(Name = "Adı")]
        public int adi { get; set; }

        [Required]
        [Display(Name = "Tanım")]
        public string tanim { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string telefon { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string telefon2 { get; set; }

        [Required]
        [Display(Name = "Cep Telefonu")]
        public string cepTelefonu { get; set; }

        [Required(ErrorMessage = "Lütfen  Eposta Adresinizi Giriniz")]
        [Display(Name = "EPosta")]
        public string epostaAdresi { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime eklenmeTarihi { get; set; }

        [Required]
        [Display(Name = "Değiştirme Tarihi")]
        public DateTime degistirmeTarihi { get; set; }
    }
}