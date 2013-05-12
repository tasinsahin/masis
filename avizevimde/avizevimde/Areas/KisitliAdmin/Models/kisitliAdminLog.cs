using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class kisitliAdminLog
    {
        [Key]
        [Display(Name="Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name="Kaynak")]
        public string logKaynak { get; set; }

        [Required]
        [Display(Name="Olay")]
        public string logOlay { get; set; }

        [Required]
        [Display(Name = "Kısıtlı Admin")]
        public int kisitliAdminId { get; set; }

        [Required]
        [Display(Name = "Tarih")]
        public DateTime? eklenmeTarihi { get; set; }

        [ForeignKey("kisitliAdminId")]
        public virtual Areas.KisitliAdmin.Models.UserProfileKisitliAdmin kisitliAdmin { get; set; }
    }
}