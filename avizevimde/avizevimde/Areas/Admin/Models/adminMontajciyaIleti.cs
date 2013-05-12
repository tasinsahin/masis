using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class adminMontajciyaIleti
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string baslik { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }

        [Required]
        [Display(Name = "Admin")]
        public int adminId { get; set; }

        [Required]
        [Display(Name = "Montajcı")]
        public int montajciId { get; set; }

        [Required]
        [Display(Name = "Tarih")]
        public DateTime? tarih { get; set; }

        [Required]
        [Display(Name = "Okundu")]
        public bool okundu { get; set; }
         
        [ForeignKey("adminId")]
        public virtual UserProfileAdmin admin { get; set; }
        public virtual avizevimde.Areas.Montajci.Models.montajci montajci { get; set; }
    }
}