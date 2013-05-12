using avizevimde.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Montajci.Models
{
    public class MontajciAdres
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Display(Name = "Montajcı")]
        public int montajciId { get; set; }

        [Display(Name = "Şehir")]
        public int sehirId { get; set; }

        [Display(Name = "İlçe")]
        public int ilceId { get; set; }

        [Display(Name = "Semt")]
        public int semtId { get; set; }

        [Display(Name = "Mahalle")]
        public int mahalleId { get; set; }

        [Required]
        [Display(Name = "Cadde")]
        public string cadde { get; set; }

        [Required]
        [Display(Name = "Sokak")]
        public string sokak { get; set; }

        [Required]
        [Display(Name = "Numara")]
        public string numara { get; set; }

        [Required]
        [Display(Name = "Enlem")]
        public int enlem { get; set; }

        [Required]
        [Display(Name = "Boylam")]
        public int boylam { get; set; }

        [Required]
        [Display(Name = "Adres Adi")]
        public int adresAdi { get; set; }

        [Required]
        [Display(Name = "Adres Fatura")]
        public bool adresFatura { get; set; }

        [Required]
        [Display(Name = "Adres Teslimat")]
        public bool adresTeslimat { get; set; }

        [Required]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        public int degistirilenId { get; set; }

        public bool enYeni { get; set; }

        [ForeignKey("sehirId")]
        public virtual sehir sehir { get; set; }
        [ForeignKey("ilceId")]
        public virtual ilce ilce { get; set; }
        [ForeignKey("semtId")]
        public virtual semt semt { get; set; }
        [ForeignKey("mahalleId")]
        public virtual mahalle mahalle { get; set; }
        [ForeignKey("montajciId")]
        public virtual montajci montajci { get; set; }
    }
}